    public Class App2Context : DbContext
    {
       public DbSet<Name> Names {get;set;}
       public DbSet<Course> Courses {get;set;}
    }
