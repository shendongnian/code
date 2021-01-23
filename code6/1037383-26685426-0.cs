    namespace ConsoleApplication1
    {
        class bar
        { 
        }
        class foo : bar
        { }
        class doublefoo : bar
        { }
        class Program
        {
            static void Main(string[] args)
            {
                var f1 = new foo();
                var f2 = new doublefoo();
                someMethod(f1);
                someMethod(f2);
            }
            public static void someMethod<t>(t something) where t: bar
            {
            }
        }
    }
