      protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {                
               modelBuilder.Entity<User>().HasMany(t => t.Friends )
              .WithMany(t => t.IFriendsForUsers )
              .Map(c => { c.ToTable("UserFriends"); 
               c.MapLeftKey("UserId"); c.MapRightKey("UserFriendId"); });
             
              base.OnModelCreating(modelBuilder);
            } 
