     RegimesEntities _Context = new RegimesEntities();
    
            public RegimesService()
            {
                _Context.Configuration.LazyLoadingEnabled = false;
                _Context.Configuration.ProxyCreationEnabled = false;
            }
