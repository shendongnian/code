    public static void RegisterIoc(HttpConfiguration config)
    {
         var kernel = new StandardKernel();    
        
         kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
         kernel.Bind<IRepository<Store>>().To<Repository<Store>>();
         kernel.Bind<IRepository<Product>>().To<Repository<Product>>();
            
    }
