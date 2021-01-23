    using System;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                Call("a", "b", method1, method2, method3);
                // You can pass as many methods as you need:
                Call("a", "b", method1, method2, method3, method1, method2, method3);
            }
            public static void Call<T1, T2>(T1 arg1, T2 arg2, params Action<T1, T2>[] actions)
            {
                foreach (var action in actions)
                    action(arg1, arg2);
            }
            private static void method1(string a, string b)
            {
                Console.WriteLine("method1(), a = " + a + ", b = " + b);
            }
            private static void method2(string a, string b)
            {
                Console.WriteLine("method2(), a = " + a + ", b = " + b);
            }
            private static void method3(string a, string b)
            {
                Console.WriteLine("method3(), a = " + a + ", b = " + b);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
