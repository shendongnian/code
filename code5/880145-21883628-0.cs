    public int? PrimaryParentId { get; set; }
    public int? SecondaryParentId { get; set; }
    
    [ForeignKey( "PrimaryParent" )]
    public virtual HierarchicalEntity PrimaryParent { get; set; }
    
    [ForeignKey( "SecondaryParent" )]
    public virtual HierarchicalEntity SecondaryParent { get; set;}
