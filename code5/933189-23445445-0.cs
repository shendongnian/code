        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().
                HasOptional(e => e.Witness).
                WithMany().
                HasForeignKey(m => m.WitnessID);
            modelBuilder.Entity<Member>().
                HasOptional(e => e.Reference).
                WithMany().
                HasForeignKey(m => m.ReferenceID);
            base.OnModelCreating(modelBuilder);
    
        }
