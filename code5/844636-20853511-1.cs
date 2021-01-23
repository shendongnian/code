    public class Foo
    {
        public int FooId { get; set; }
        public virtual ICollection<Bar> Bars { get; set; }
    }
    public class Bar
    {
        public int BarId { get; set; }
        public int FooId { get; set; }
        public virtual Foo Foo { get; set; }
    }
