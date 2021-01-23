    class Program
    {
        static void Main(string[] args)
        {
            FooStruct f = new FooStruct();
            f.Val = 2;
            FooClass f2 = (FooClass)f;
            Console.Read();
        }
    }
    class FooClass : IFoo
    {
        public static explicit operator FooClass(FooStruct f)
        {
            FooClass foo = new FooClass();
            foo.Val = f.Val;
            return foo;
        }
        public int Val { get; set; }
    }
    struct FooStruct : IFoo
    {
        public int Val { get; set; }
        public static explicit operator FooStruct(FooClass f)
        {
            FooStruct foo = new FooStruct();
            foo.Val = f.Val;
            return foo;
        }
    }
    // This interface has little use in this scenario.
    interface IFoo
    {
        int Val { get; set; }
    }
