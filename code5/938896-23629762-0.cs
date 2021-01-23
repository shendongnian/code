    class Foo
    {
        public static bool operator == (Foo x, Foo y)
        {
            return false; // probably more complex stuff here in the real code
        }
        public static bool operator != (Foo x, Foo y)
        {
            return !(x == y);
        }
        static void Main()
        {
            Foo obj = null;
            System.Diagnostics.Debugger.Break();
        }
        // note there are two compiler warnings here about GetHashCode/Equals;
        // I am ignoring those for brevity
    }
