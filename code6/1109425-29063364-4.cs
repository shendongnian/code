    public class InformationDBContext : DbContext
    {
        public InformationDBContext()
            : base(ConfigurationManager.ConnectionStrings["DataDBString"].ConnectionString)
        {
        }
        public DbSet<Information> Informations { get; set; }
    	public DbSet<InformationContainer> InformationContainers { get; set; }
    }
