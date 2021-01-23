    public static class ExtensionMethods
    {
        public static void Method<T>(this T parameter) //where T : SomeInterface
        { }
        public static void Method<T>(this IEnumerable<T> parameter) //where T : SomeInterface 
        { }
    }
