    PlayerController myCharactersScript;
    void Start(){
         myCharactersScript = GameObject.Find("myCharactersName").GetComponent<PlayersController>();
    }
    public void OnTriggerEnter2D(Collider2D target){
    if (target.gameObject.tag == "Deadly") {
        Destroy (gameObject);
       myCharactersScript.BulletCount();
    }
    }
     
