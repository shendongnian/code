    public class FooBarRec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Foo FooRec { get; set; }
        public Bar BarRec { get; set; }
    }
    public class Foo
    {
        public int FooId { get; set; }
        public string FooName { get; set; }
    }
    public class Bar
    {
        public int BarId { get; set; }
        public string BarName { get; set; }
    }
