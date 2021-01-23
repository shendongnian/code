     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
            modelBuilder.Entity<App>()
                .HasOptional(a => a.Colleague)
                .WithMany(c => c.Apps)
                .HasForeignKey(a => a.ColleagueId);
     }
