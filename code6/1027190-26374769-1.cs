    public class Bundesland
    {
        [Key]
        [ForeignKey("Programmkonfiguration")]
        public Guid Id { get; set; }
    
        public virtual Programmkonfiguration Programmkonfiguration { get; set; }
    }
    
    public class BundesLandConfiguration: EntityTypeConfiguration<Bundesland>
    {
        public BundesLandConfiguration()
        {            
            HasProperty(p=>p.Id)
            HasRequired(p=>p.Programmkonfiguration).WithRequiredPrincipal(p=>p.Bundesland);
        }
    }
    
    public class Programmkonfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    
        public Guid Bundesland_Id { get; set; }
    
        public virtual Bundesland Bundesland { get; set; }
    }
    
    public class ProgrammkonfigurationConfiguration: EntityTypeConfiguration<Programmkonfiguration>
    {
        public ProgrammkonfigurationConfiguration()
        {
            HasKey(p=>p.Id);
            HasProperty(p=>p.Id)
            HasProperty(p=>p.Bundesland_Id)
        }
    }
