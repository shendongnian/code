    public class Foo
    {
        public int Id { get; set; }
        public int BarId { get; set; }
        public virtual Bar Bar { get; set; }
    }
    public class Bar
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual ICollection<Foo> Foos { get; set; }
    }
