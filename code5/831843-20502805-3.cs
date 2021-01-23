        public CustomerDataContext(IConnectionStringManager connectionStringManager)
        {
            var connectionString = connectionStringManager.GetConnectionString();
            // pass the connectionString to your context
        }
