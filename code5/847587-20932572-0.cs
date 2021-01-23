    public static class Extension
    {
        public static void Method1(this IMyInterface myInterface, int i)
        {
            Console.WriteLine("Extension.Method1");
        }
        public static void Method1(this IMyInterface myInterface, string s)
        {
            Console.WriteLine("Extension.Method1");
        }
    }
