    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Games>().HasMany(x=> x.Genres)
            .WithMany(x => x.Games)
            .Map(x => x.MapLeftKey("ID").MapRightKey("ID").ToTable("Genre"));
        modelBuilder.Entity<Genre>().HasMany(x => x.Games)
            .WithMany(x => x.Genres)
            .Map(x => x.MapLeftKey("ID").MapRightKey("ID").ToTable("Games"));
    }
