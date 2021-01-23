       public SystemContext() :
            base("SystemContext")
        {
            Database.SetInitializer<SystemContext>(null);
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }
