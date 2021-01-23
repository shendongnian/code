    {
            Database.SetInitializer<yourDatabaseContextName>(null);
            var adapter = (System.Data.Entity.Infrastructure.IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 120; //2 minutes
        }
