    public class Bundesland
    {
        public Guid Id { get; set; }
    
        public virtual Programmkonfiguration Programmkonfiguration { get; set; }
    }
    
    public class BundesLandConfiguration: EntityTypeConfiguration<Bundesland>
    {
        public BundesLandConfiguration()
        {
            HasKey(p=>p.Id);
            HasProperty(p=>p.Id)
            HasRequired(p=>p.Programmkonfiguration)..WithRequiredPrincipal(p=>p.Bundesland)
        }
    }
    
    public class Programmkonfiguration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    
        public Guid BundeslandId { get; set; }
    
        public virtual Bundesland Bundesland { get; set; }
    }
    
    public class ProgrammkonfigurationConfiguration: EntityTypeConfiguration<Programmkonfiguration>
    {
        public ProgrammkonfigurationConfiguration()
        {
            HasKey(p=>p.Id);
            HasProperty(p=>p.Id)
            HasProperty(p=>p.BundeslandId)
        }
    }
