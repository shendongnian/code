    public class DuckBehaviour : MonoBehaviour {
    
    Vector3 velocity = Vector3.zero;
    float speed = 1f;
    float verticality;
    
    
    
    // Use this for initialization
    void Start () {
        velocity.y = 0.7f;
    }
    
    // Update is called once per frame
    void Update () {
        //Requires that an orthographic camera named "MainCamera" exists with y transform of 0
        if (transform.position.y < -Camera.main.orthographicSize) {
            velocity.y = 0.7f;
        } else if (transform.position.y > Camera.main.orthographicSize) {
            velocity.y = -0.7f;
        }
        transform.position += velocity * Time.deltaTime;
    }
    }
