    public class ProjectComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectComponentID { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
        public int ProjectPhaseID { get; set; }
        public virtual ProjectPhase Phase { get; set; }
        ... other properties ...
        public virtual Specification Specification { get; set; }
    }
    public class Specification
    {
        public int SpecificationID { get; set; }
        public virtual ProjectComponent ProjectComponent { get; set; }
        public string Description { get; set; }
    }
