    public class Entity2
    {
        [Key]
        public Guid Entity2Id { get; set; }
        /* Describe the other properties here */
        [Display(Name = "AssociativeEntities", ResourceType = typeof(Resources.Language))]
        public virtual ICollection<AssociativeEntity> AssociativeEntities { get; set; }
    }
