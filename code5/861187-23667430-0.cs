    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<JohnsChildTable>()
                   .HasRequired(t=>t.JohnsParentTable)
                   .WithMany(t=>t.JohnsChildTables)
                   .HasForeignKey(d=>d.JohnsParentTableId)
                   .WillCascadeOnDelete(true);
    
                base.OnModelCreating(modelBuilder);
    }
