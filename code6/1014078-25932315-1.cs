    public GameObject a; // you will need this if scriptB is in another GameObject
                         // if not, you can omit this
                         // you'll realize in the inspector a field GameObject will appear
                         // assign it just by dragging the game object there
    public scriptA script; // this will be the container of the script
    
    void Start(){
        // first you need to get the script component from game object A
        // getComponent can get any components, rigidbody, collider, etc from a game object
        // giving it <scriptA> meaning you want to get a component with type scriptA
        // note that if your script is not from another game object, you don't need "a."
        script = a.gameObject.getComponent<scriptA>();
    }
    
    void Update(){
        // and you can access the variable like this
        // even modifying it works
        scriptA.X = true;
    }
