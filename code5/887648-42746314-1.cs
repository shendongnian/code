    GameObject myCube;
    
    void Start(){
        // Lets say you have a script attached called Cubey.cs, this solution takes a bit of time to compute. 
        myCube = GameObject.FindObjectOfType<Cubey>();
    }
    
    // This is a usually a better approach, You need to attach cubey through the inspector for this to work.
    public GameObject myCube; 
