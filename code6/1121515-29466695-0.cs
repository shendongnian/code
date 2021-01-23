     // // Update is called once per frame
     void Update () {
     if(isDead == true){
        RESTART_BUTTON.gameObject.SetActive(true);
        }
    }
    void Start () {
        if(isDead == false){
        RESTART_BUTTON.gameObject.SetActive(false);
        }
     }
    public void OnCollisionEnter2D(Collision2D collision){
    Debug.Log(collision.gameObject.tag);
    if(collision.gameObject.tag == "Death"){
        isDead = true;
    } 
    }
