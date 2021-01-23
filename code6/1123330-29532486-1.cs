    2) use [notmapped] on PreqEdge referencing properties as 
    [notmapped]    
    public virtual Course Parent { get; set; }
    [notmapped]
    public virtual Course Child { get; set; }
    This is just to break the cycle.
