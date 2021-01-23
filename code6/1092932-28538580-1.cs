    public class FooConfiguration : EntityTypeConfiguration<Foo>
    {
        public FooConfiguration()
        {
            this.HasKey(x => x.ID);
    
            this.HasOptional(f => f.firstFk)
                .WithOptionalDependent(f => f.secondFk);
        }
    }
