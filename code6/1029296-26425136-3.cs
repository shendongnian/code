    public MyClass
    {
        public static int myVariable = 5;
    }
    public static class ExtensionMethods
    {
        private static readonly Dictionary<Enum, string> s_EnumMap = new Dictionary<Enum, string>
            {
                { Foo.One, string.Format("{0} - {1}","Option One", MyClass.myVariable) },
                { Foo.Two, string.Format("{0} - {1}","Option Two", 2) }
            };
        public static String ConvertToString(this Enum eff)
        {
            return s_EnumMap[eff];
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Foo.One.ConvertToString());
            Console.WriteLine(Foo.Two.ConvertToString());
            MyClass.myVariable = 100;
            Console.WriteLine(Foo.One.ConvertToString());
            Console.WriteLine(Foo.Two.ConvertToString());
        }
    }
