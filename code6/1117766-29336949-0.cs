    //In Class one
    public List<Parent> parent; 
    parent.Add(new Child());
    
    //In Class two
    Child parentAsChild = parent[0] as Child;
    if (parentAsChild != null)
    {
        Console.WriteLine(parentAsChild.name());
    }
