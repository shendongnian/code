    public class Component
    {
        public Guid ID { get; set; }
        public Guid Name { get; set; }
        public virtual ICollection<Component> Masters { get; set; }
        public virtual ICollection<Component> Components { get; set; }       
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Component>()
            .HasMany(c => c.Components)
            .WithMany(c => c.Masters)
            .Map(xref => xref.MapLeftKey("ParentID").MapRightKey("ChildID").ToTable("ComponentXref"));
    }
