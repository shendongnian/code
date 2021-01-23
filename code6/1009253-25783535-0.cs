    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Callmethod();
                Console.WriteLine("--------------------");
                Console.WriteLine("Disposed");
                Console.ReadKey();
            }
    
            private static string Callmethod()
            {
                using (MyObject obj = new MyObject())
                {
                    Console.WriteLine(obj.strTest);
                    Console.WriteLine("..");
                    Console.WriteLine("..");
                    Console.WriteLine("..");
                    Console.WriteLine("..");
                    return obj.strTest;
                }
            }
        }
        public class MyObject : IDisposable
        {
            public string strTest { get; set; }
            public MyObject()
            {
                strTest = "Intantiated";
            }
    
            public void Dispose()
            {
                Console.WriteLine("Disposing");
            }
        }
    }
