    GameObject myCube;
    
    void Start(){
        // Lets say you have a script attached called Cubey.cs
        // This is a slow approach
        myCube = GameObject.FindObjectOfType<Cubey>();
    }
    
    // A faster approach is to do
    // You need to then attach cubey through the inspector
    public GameObject myCube; 
