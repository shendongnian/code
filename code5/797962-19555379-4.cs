    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<user>().
          HasMany(c => c.Buddies).
          WithMany().
          Map(
           m =>
           {
              m.MapLeftKey("user_id");
              m.MapRightKey("buddy_id");
              m.ToTable("buddies");
           });
    }
