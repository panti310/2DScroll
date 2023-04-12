using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ジャンプ力
    public float jumpForce;

    // 横移動速度
    public float moveSpeed;

    // 地面にいるかどうかのフラグ
    private bool isGrounded;

    // Rigidbody2Dコンポーネント
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面にいる状態でSpaceキーが押されたらジャンプする
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 左右の移動処理
        float move = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
    }

    // 衝突判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 地面と衝突した場合
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // 障害物と衝突した場合
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ゲームオーバー処理
            GameOver();
        }
    }

    // トリガー判定
    void OnTriggerEnter2D(Collider2D other)
    {
        // ゴールオブジェクトと衝突した場合
        if (other.gameObject.CompareTag("Goal"))
        {
            // ゲームクリア処理
            GameClear();
        }
    }

    // ゲームオーバー処理
    private void GameOver()
    {
        // ゲームオーバー時の処理をここに書く
        Debug.Log("Game Over");
    }

    // ゲームクリア処理
    private void GameClear()
    {
        // ゲームクリア時の処理をここに書く
        Debug.Log("Game Clear");
    }
}
