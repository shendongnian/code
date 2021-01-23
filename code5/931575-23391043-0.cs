    public class Foo 
    {
        public int FooId { get; set; }
        // ...Other instance members
        public byte[] ConcurrencyCheck { get; private set; }
    }
    public class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            Property(t => t.ConcurrencyCheck)
                .IsRowVersion();
        }
    }
