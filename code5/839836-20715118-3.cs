    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                ObjImpl a = new ObjImpl();
                ObjTImpl b = new ObjTImpl();
                Console.WriteLine(a.Duplicate().GetType());
                Console.WriteLine(b.Duplicate().GetType());
                Console.ReadLine();
            }
        }
    }
    // outputs:
    // ObjImpl
    // ObjTImpl
