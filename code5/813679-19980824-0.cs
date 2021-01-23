    public GameObject Camera;
    public float moveSpeed = 0.0f;
    
    if (Input.GetKey ("right") || Input.GetKey ("d")) {
    	rigidbody.AddForce( Camera.transform.right * moveSpeed * Time.deltaTime);
    }
    
    if (Input.GetKey ("left") || Input.GetKey ("a")) {
    	rigidbody.AddForce( -Camera.transform.right * moveSpeed * Time.deltaTime);
    }
    
    if (Input.GetKey ("up") || Input.GetKey ("w")) {
    	rigidbody.AddForce( Camera.transform.forward * moveSpeed * Time.deltaTime);
    }
    
    if (Input.GetKey ("down") || Input.GetKey ("s")) {
    	rigidbody.AddForce( -Camera.transform.forward * moveSpeed * Time.deltaTime);
    }
 
