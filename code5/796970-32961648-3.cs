    // Foo.cs
    public class Foo
    {
        public Guid Id { get; set; }
    
        public ICollection<Bar> Bars { get; set; }
    }
    
    // Bar.cs
    public class Bar
    {
        public Guid Id { get; set; }
        
        public Guid? FooId { get; set; }
    
        public virtual Foo Foo { get; set; }
    }
    
    // MyDbContext
    modelBuilder.Entity<Foo>()
        .HasMany(e => e.Bars)
        .WithRequired(e => e.Foo)
        .HasForeignKey(e => e.FooId)
        .WillCascadeOnDelete(false);
