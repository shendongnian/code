    public partial class ClientRep : Person
    {
        public ClientRep()
        {
            this.Jobs = new ObservableCollection<Job>();
        }
        public int ClientId { get; set; }
        public bool? IsPrimaryContact { get; set; }
        public string JobContactType { get; set; }
        public Client Client { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
    public class ClientRepMap : EntityTypeConfiguration<ClientRep>
    {
        public ClientRepMap()
        {
            this.ToTable("People_ClientRep");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.IsPrimaryContact).HasColumnName("IsPrimaryContact");
            this.Property(t => t.JobContactType).HasColumnName("JobContactType");
            this.HasMany(t => t.Jobs)
                .WithMany(t => t.ClientReps)
                .Map(m =>
                    {
                        m.ToTable("JobClientRep");
                        m.MapLeftKey("ClientRep_Id");
                        m.MapRightKey("Job_Id");
                    });
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientReps)
                .HasForeignKey(d => d.ClientId).WillCascadeOnDelete(false);
        }
    }
