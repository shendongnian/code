    protected ApplicationDbContext Db {get; set;}
    
    public TestHub()
    {
      Db = new ApplicationDbContext();
    }
