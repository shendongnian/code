    namespace ConsoleApplication1
    {
        public class BaseHome
        {
            static BaseHome()
            {
                Console.WriteLine("B");
    
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            }
    
            public static void Main()
            {
                Console.WriteLine("A");
            }
    
            private static void OnProcessExit(object sender, EventArgs e)
            {
                Console.WriteLine("C");
                Console.Read();
            }
        }
    }
