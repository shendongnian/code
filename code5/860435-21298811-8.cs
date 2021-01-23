    class Program
    {
        static void Main(string[] args)
        {
            // Direct cast from integer -- no error here
            MyEnum x = (MyEnum)123;
            Console.WriteLine(x);
            // Parsing a numeric string -- no error here either
            MyEnum y = (MyEnum)Enum.Parse(typeof(MyEnum), "456");
            Console.WriteLine(y);
        }
        public enum MyEnum
        {
            Zero = 0,
            One = 1,
            Two = 2
        }
    }
