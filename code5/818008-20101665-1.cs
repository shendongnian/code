    public class Foo : Baz
    {
        public string Name { get; set; }
        public int BarID { get; set; }
        public virtual Bar Bar { get; set; }
    }
    public class Baz
    {
        public int ID { get; set; }
        public int ApprovedBy { get; set; 
    }
