    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                        .HasOptional(i => i.ParentItem)
                        .WithMany(i => i.ChildItems)
                        .HasForeignKey(i => i.ParentItemId);
        }
