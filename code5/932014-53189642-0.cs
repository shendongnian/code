    enter code here
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 desiredPosition;
    void FixedUpdate(){
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, 
                                      desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;    
    }
