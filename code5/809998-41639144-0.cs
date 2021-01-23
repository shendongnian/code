    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyConnStr", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    
    	public System.Data.Entity.DbSet<FileUpload.Models.FileTypesView> FileTypesViews { get; set; }
    }
      <connectionStrings>
        <add name="MyConnStr" connectionString="data source=xxx;initial catalog=&quot;xxx&quot;;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
      </connectionStrings>
