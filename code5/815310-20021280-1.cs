        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired<Team>(i => i.TeamHome)
                        .WithMany(i => i.Matches)
                        .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
