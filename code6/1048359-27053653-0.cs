        public ApplicationDbContext(string nameOfConnection)
            : base(nameOfConnection)
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }
