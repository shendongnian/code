    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<User>().
             HasMany(m => m.Friends).
             WithMany()
             .Map(m =>
             {
                 m.ToTable("UsersFriends");
                 m.MapLeftKey("UserId");
                 m.MapRightKey("FriendId");
             });
    }
