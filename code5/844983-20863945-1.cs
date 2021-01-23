    public class ClientStaticsViewConfiguration : EntityTypeConfiguration<ClientStaticsView>
    {
        public ClientStatusViewConfiguration
        {
           ToTable("ClientStatics");
        }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Configurations.Add(new ClientStatisViewConfiguration());
    }
