    public class AssociativeEntity
    {
        [Key]
        public Guid AssociativeEntityId { get; set; }
        public Guid Entity1Id { get; set; }
        public Guid Entity2Id { get; set; }
        [Display(Name = "Entity1", ResourceType = typeof(Resources.Language))]
        public virtual Entity1 Entity1 { get; set; }
        [Display(Name = "Entity2", ResourceType = typeof(Resources.Language))]
        public virtual Entity2 Entity2 { get; set; }
    }
