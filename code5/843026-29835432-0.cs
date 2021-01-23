        static void SetupDBTransaction()
        {
            System.Data.Entity.Fakes.ShimDbContextTransaction transaction = new System.Data.Entity.Fakes.ShimDbContextTransaction();
            transaction.Commit = () => { };
            transaction.Rollback = () => { };
            System.Data.Entity.Fakes.ShimDatabase database = new System.Data.Entity.Fakes.ShimDatabase();
            database.BeginTransactionIsolationLevel = (isolationLevel) =>{return transaction.Instance;};
            System.Data.Entity.Fakes.ShimDbContext.AllInstances.DatabaseGet = (@this) => { return database.Instance; };
        }
