    public class Entity1
    {
        [Key]
        public Guid Entity1Id { get; set; }
        /* Describe the other properties here */
        [Display(Name = "AssociativeEntities", ResourceType = typeof(Resources.Language))]
        public virtual ICollection<AssociativeEntity> AssociativeEntities { get; set; }
    }
