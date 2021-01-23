    #if DEBUG  
    protected override void OnConfiguring(DbContextOptions options)
    {
         options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=localSQLdb;Trusted_Connection=True;MultipleActiveResultSets=true");
         base.OnConfiguring(options);
    }
    #endif
