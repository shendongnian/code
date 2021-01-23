    public class MoveRacket : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";
    public object racket = "Racket";
    public bool touchInput = true;
    public Vector2 touchPos;
    void FixedUpdate () {
        //used to not have anything in parentheses
        //float v = Input.GetAxisRaw (axis);
        float v = Input.GetAxisRaw (axis);
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, v) * speed;
        if (Input.touchCount == 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPos = new Vector2(wp.x, wp.y);
            if (Physics2D.OverlapPoint(touchPos) != null)
            {
                this.transform.position =  new Vector3 (3.94f,wp.y,0);
        }
        }
    }
    }
