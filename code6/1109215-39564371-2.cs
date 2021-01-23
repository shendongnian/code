    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            optionsBuilder.UseSqlite("Filename=./{dbname}.db");
        }
    }
