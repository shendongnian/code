    //In Class one
    public List<Parent> parent; 
    parent.Add(new Child());
    
    
    //In Class two
    var child = parent[0] as Child;
    if (child != null)
    {
       //treats it as parent
       Console.WriteLine(child.name());
    }
