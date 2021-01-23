     interface IFoo
      {
        int A { get; set; }
       }
    class FooBar : IFoo
    {
        public int r { get; set; }
        public int A { get; set; }
    }
    class FooBaz : IFoo
    {
        public int z { get; set; }
        public int A { get; set; }
    }
