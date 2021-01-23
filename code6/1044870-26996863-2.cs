    public class Foo {
        public int FooId {get; set;}
        public string Name {get; set;}
        // Relationships
        public int? ParentFooId {get; set;} // a Foo has many SubFoos, a Foo has one optional ParentFoo
        public virtual Foo ParentFoo {get; set;}
        public virtual ICollection<Foo> SubFoos {get; set;}
    }
