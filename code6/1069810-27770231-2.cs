    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.Associations)
                    .WithRequired(a => a.User).HasForeignKey(a => a.UserID)
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<User>().HasMany(u => u.Associations)
                    .WithRequired(a => a.Friend).HasForeignKey(a => a.FriendID)
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<UserAssociation>()
                    .HasKey(a => new {a.UserID, a.FriendID});
    }
