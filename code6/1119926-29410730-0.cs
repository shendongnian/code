    using System;
    
    namespace Testing
    {
        internal class Program
        {
            public static void visitorTest(Action<int> visitor)
            {
                int[] tmp = new int[10];
                for (int i = 0; i < tmp.Length; i++)
                {
                    tmp[i] = i;
                }
                foreach (var i in tmp)
                {
                    visitor(i);
                }
            }
    
            public static void funcCallback(int arg)
            {
                System.Console.WriteLine("func: " + arg.ToString());
            }
    
            private static void Main(string[] args)
            {
                //An object reference is required for the non-static field, method, or property 'ConsoleTest.Program.visitorTest(ConsoleTest.Program.Visitor)
                visitorTest(funcCallback);
    
                int mul = 2;
                Action<int> lambda = (i) => System.Console.WriteLine("lambda: " + (2 * i).ToString());
    
                //The best overloaded method match for 'ConsoleTest.Program.visitorTest(ConsoleTest.Program.Visitor)' has some invalid arguments    
                //Argument 1: cannot convert from 'System.Action<int>' to 'ConsoleTest.Program.Visitor'
                visitorTest(lambda);
                Console.Read();
            }
        }
    }
