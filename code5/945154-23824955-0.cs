    public class Bar
    {
        public int Id { get; set; }
        public virtual Foo Foo { get; set; }
    }
    public class FooMapping : EntityTypeConfiguration<Foo>
    {
        public FooMapping()
        {
            HasKey(f => f.Id);
            HasMany(f => f.Bars)
                .WithRequired(b => b.Foo); //check this syntax, I'm not entirely sure.
        }
    }
