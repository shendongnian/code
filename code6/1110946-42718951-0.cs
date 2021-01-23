    private readonly bool isMigration = false;
    public MyContext()
    {
        isMigration = true;
    }
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (isMigration)
        {
            optionsBuilder.UseSqlServer("CONNECTION_STRING");
        }
    }
