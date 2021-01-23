    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<TableB>()
                    .HasRequired(x => x.B)
                    .WithMany()
                    .HasForeignKey(x => x.B_ID).WillCascadeOnDelete(false);
    
                modelBuilder.Entity<TableB>()
                    .HasRequired(x => x.C)
                    .WithMany()
                    .HasForeignKey(x => x.C_ID).WillCascadeOnDelete(false);
    
                base.OnModelCreating(modelBuilder);
            }
