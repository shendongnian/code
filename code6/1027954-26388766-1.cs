    public class MyClass
    {
        public static readonly MyClass Instance = new MyClass();
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static MyClass() { }
    }
