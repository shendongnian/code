    public class Foo {
        public int FooId {get; set;}
        public string Name {get; set;}
        // Relationships
        public virtual ICollection<Bar> Bars {get; set;} // a Foo has many bars, a Bar has one optional Foo
    }
    public class Bar {
        public int BarId {get; set;}
        public string Name {get; set;}
        // Relationships
        public int? FooId {get; set;} // a Foo has many bars, a Bar has one optional Foo
        public virtual Foo Foo {get; set;}
    }
