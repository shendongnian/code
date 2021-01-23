    public Def[] defArray;
    public Defs gameobject; ///if you want to access from another class assign this your Defs gameobject from inspector
    
    defs = Defs.GetComponents<Def>();  ///if you want access from another game object
    defs = gameObject.GetComponents<Def>();  ///if Defs is attached to this gameObject
     
