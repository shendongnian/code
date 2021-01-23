    class Base { }
    class Child : Base { }
    class Program
    {
        static void Main(string[] args)
        {
            Base node = GetChild();
            Test((dynamic)node);
            node = GetBase();
            Test((dynamic) node);
        }
        static Child GetChild()
        {
            return null;
        }
        static Base GetBase()
        {
            return null;
        }
        // Guess how many times each method is called..
        static void Test(Base node)
        {
            // Nope!
        }
        static void Test(Child child)
        {
            // It's this one twice.
        }
    }
