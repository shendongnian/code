    public static bool isMigration = true;
    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        // TODO: This is messy, but needed for migrations.
        // See https://github.com/aspnet/EntityFramework/issues/639
        if ( isMigration )
        {
            optionsBuilder.UseSqlServer( "<Your Connection String Here>" );
        }
    }
