      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Entity<EFUser>()
        .HasOptional(c => c.ManagerUser)
        .WithMany()
        .HasForeignKey(c => c.ManagerUserID);
      }
