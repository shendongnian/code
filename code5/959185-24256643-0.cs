    using System;
    namespace SO24255725
    {
        public static class Extension
        {
            public static int Count(this Program a)
            {
                return 42;
            }
        }
        
        public class Program
        {
            static void Main()
            {
                Program test = new Program();
                PrintCount(test);
            }
            static void PrintCount(dynamic data)
            {
                Console.WriteLine(data.Count());
            }
        }
    }
