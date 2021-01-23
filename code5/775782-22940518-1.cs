    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                        .HasOptional(i => i.ParentItem)
                        .WithMany()
                        .HasForeignKey(i => i.ParentItemId);
        }
