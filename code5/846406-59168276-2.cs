      public  class ABCDbContext:DbContext
    {
        public ABCDbContext(DbContextOptions<ABCDbContext> options)
           : base(options)
        {
        }
     public DbSet<SP_reslutclass> SP_reslutclass { get; set; }
    }
