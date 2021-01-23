    public static void RegisterIoc(HttpConfiguration config)
    {
         var container = new Container();
        
         container.Register<IUnitOfWork, UnitOfWork>();
         container.Register<IRepository<Store>, Repository<Store>>();
         container.Register<IRepository<Product>, Repository<Product>>();
            
    }
