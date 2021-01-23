    public AppDbContext : DbContext
    {
        private const string _defaultCS = "default app connection string";
        
        public AppDbContext() : base(GetConnectionString())
        {
        }
        
        private string GetConnectionString()
        {
            return TenantContext.ConnectionString ?? _defaultCS;
        }
    }
