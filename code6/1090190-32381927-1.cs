    private static void RegisterReleaseEnv(IUnityContainer container)
            {
                //Repository Registration
                container             
                  .RegisterType(typeof(IRepository<>), typeof(GenericRepository<>), new HierarchicalLifetimeManager());
    
            }
