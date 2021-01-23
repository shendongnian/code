    class BaseClass
    {
        public int Base { get; set; }
    }
    class ChildClass : BaseClass
    {
        public double Child { get; set; }
    }
    class ChildChildClass : ChildClass
    {
        public string ChildChild { get; set; }
    }
