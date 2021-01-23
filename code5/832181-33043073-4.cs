    namespace ConsoleTests
    {
        using System;
        using System.Collections.Generic;
        internal class Program
        {
            private static List<int> stuff;
            private static int Bar(int value)
            {
                return stuff[value];
            }
            private static int Foo()
            {
                return Bar(5);
            }
            private static void Main()
            {
                stuff = new List<int>();
                int num = Foo();
            }
        }
    }
