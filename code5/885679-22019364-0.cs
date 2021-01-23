    public class SqlResourceProviderFactory : ResourceProviderFactory
    {
      public IServiceManager ServiceManager { get; set; }
      public SqlResourceProviderFactory()
      {
        this.ServiceManager =
          DependencyResolver.Current.GetService<IServiceManager>();
      }
    }
