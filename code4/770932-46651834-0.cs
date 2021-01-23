        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Parent>()
                .HasOptional(a => a.Child) /* LEFT OUTER JOIN */
                .WithMany()
                .HasForeignKey(a => a.ChildId);
        }
