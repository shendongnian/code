    namespace ConsoleApplication1
    {
        class bar
        { public void stuff() { } }
        class foo : bar
        { }
        class doublefoo : bar
        { }
        class Program
        {
            static void Main(string[] args)
            {
                someMethod<foo>();
                someMethod<doublefoo>();
            }
            public static void someMethod<t>() where t: bar, new()
            {
                t myBar = new t();
                myBar.stuff();
            }
        }
    }
