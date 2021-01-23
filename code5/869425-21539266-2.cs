    [Table("EntityA")]
    public partial class EntityA
    {
        public int EntityAId { get; set; }
        public string Description { get; set; }
        
        public virtual EntityB PrimaryEntityB { get; set; }
        public virtual EntityB AlternativeEntityB { get; set; }
        public bool IsDeleted { get; set; }
    }
    [Table("EntityB")]
    public partial class EntityB
    {
        public int EntityBId { get; set; }
        public string Description { get; set; }
        [InverseProperty("PrimaryEntityB")]
        public virtual ICollection<EntityA> EntityAsViaPrimary { get; set; }
        [InverseProperty( "AlternativeEntityB" )]
        public virtual ICollection<EntityA> EntityAsViaAlternative { get; set; }
    }
