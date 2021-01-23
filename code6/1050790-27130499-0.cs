    public class Foo 
    {
        public Guid Id { get; private set; }
        public virtual ICollection<Baz> Bazs { get; private set; }
    }
    
    public class Baz 
    {
        public Guid Id { get; private set; }
        public virtual Foo Foo { get; private set; }
        public virtual Bar Bar { get; private set; }
        // other things
    }
