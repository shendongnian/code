      public class CodeBasedDatabaseConfiguration : DbConfiguration
      {
        public CodeBasedDatabaseConfiguration()
        {
          SetExecutionStrategy("System.Data.SqlServerCe.4.0", () => new DefaultExecutionStrategy());
          SetProviderFactory("System.Data.SqlServerCe.4.0", new SqlCeProviderFactory());
          SetProviderServices("System.Data.SqlServerCe.4.0", SqlCeProviderServices.Instance);
          SetProviderFactoryResolver(new CodeBasedDbProviderFactoryResolver());
        }
      }
      internal class CodeBasedDbProviderFactoryResolver : IDbProviderFactoryResolver
      {
        private readonly DbProviderFactory sqlServerCeDbProviderFactory = new SqlCeProviderFactory();
    
        public DbProviderFactory ResolveProviderFactory(DbConnection connection)
        {
          var connectionType = connection.GetType();
          var assembly = connectionType.Assembly;
          if (assembly.FullName.Contains("System.Data.SqlServerCe"))
          {
            return sqlServerCeDbProviderFactory;
          }
          if (assembly.FullName.Contains("EntityFramework"))
          {
            return EntityProviderFactory.Instance;
          }
          return null;
        }
      }
