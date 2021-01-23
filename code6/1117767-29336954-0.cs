    //In Class one
    public List<Parent> parent; 
    parent.Add(new Child());
    
    //In Class two
    if (parent[0] is Child)
    {
       var child = (Child) parent[0];
       Console.WriteLine(child.name());
    }
