    public class Foo 
    {
        //private constructor won't lazy-load navigation properties (virtual or not).
        //change to protected 
        private Foo(){}  
        public Foo(string name)
        { 
            this.Name = name; 
        }
        public string Name {get;set;}
        public Guid Id { get; private set; }
        public virtual ICollection<Baz> Bazs { get; private set; }
    }
