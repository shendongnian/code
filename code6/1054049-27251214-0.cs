    public class Application 
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long? StartScriptID { get; set; }
        // Other properties...
        // Navigation properties:
        public virtual Script StartScript { get; set; }   // new
        public virtual ICollection<Script> Scripts { get; set; }
    }
    public class Script 
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int ApplicationId { get; set; }
        // Other properties...
        // Navigation properties:
        public virtual Application Application { get; set; }
    }
    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("TB_APLICATION", "aplication");
            this.Property(t => t.ID).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("name");
            this.Property(t => t.StartScriptID).HasColumnName("startscript_id");
            this.HasOptional(t => t.StartScript)
                .WithMany()
                .HasForeignKey(t => t.StartScriptID);
        }
    }
    public class ScriptMap : EntityTypeConfiguration<Script>
    {
        public ScriptMap()
        {
            this.HasKey(t => t.ID);
            this.ToTable("TB_APLICATION", "aplication");
            this.Property(t => t.ID).HasColumnName("id");
            this.Property(t => t.Name).HasColumnName("name");
            this.HasRequired(t => t.Application)
                .WithMany(w => w.Scripts)
                .HasForeignKey(t => t.ApplicationId);
        }
    }
