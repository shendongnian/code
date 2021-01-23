    public class HierarchicalEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey( "PrimaryParent" )]
        public int? PrimaryParentId { get; set; }
        [ForeignKey( "SecondaryParent" )]
        public int? SecondaryParentId { get; set; }
        public virtual HierarchicalEntity PrimaryParent { get; set; }
        public virtual HierarchicalEntity SecondaryParent { get; set;}
        [InverseProperty( "PrimaryParent" )]
        public ICollection<HierarchicalEntity> ChildrenViaPrimaryParent { get; set; }
        
        [InverseProperty( "SecondaryParent" )]
        public ICollection<HierarchicalEntity> ChildrenViaSecondaryParent { get; set; }
    }
