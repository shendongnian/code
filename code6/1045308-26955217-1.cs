    // parent
    public ParentMapping ()
    {
        ...
        HasMany(cso => cso.Children)
           .KeyColumn("IdParent")
           .Inverse() // this is essential for optimized SQL Statements
           .Cascade.SaveUpdate() // All delete orphan would be better
           .Not.LazyLoad();
    }
    ...
    // Child
    public ChildMapping ()
    {
        ...
        References(x => x.Parent, "IdParent"); // it is a to use Inverse() 
    }
