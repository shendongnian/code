    public class AppHost : AppHostBase
    {
        public AppHost() : base("Northwind web services", typeof(CustomersService).Assembly)
        { }        
    
    
        public override void Configure( Container container )
        {
            SetConfig(new HostConfig
            {
                DebugMode = true,
                ReturnsInnerException = true,
            });         
    
            var dbFactory = new OrmLiteConnectionFactory("~/Northwind.sqlite".MapHostAbsolutePath(), SqliteDialect.Provider);
    
            container.Register(dbFactory);
    
            // Dependencies
            container.RegisterAs<CustomerEntityRepository, ICustomerEntityRepository>();
            
            container.RegisterAutoWired<CustomersService>();
                         
        }
    }
