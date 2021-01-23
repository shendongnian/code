    public class Foo
    {
        public string Data;
        public  static Foo instance = null;
        ~Foo()
        {
            Console.WriteLine("Finalized");
            instance = this;
        }
    }
    public static void Bar()
    {
        new Foo() { Data = "Hello World" };
    }
    static void Main(string[] args)
    {
        Bar();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine(Foo.instance.Data);
        Foo.instance = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
