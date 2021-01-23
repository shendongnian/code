    public class HelperFoo
    {
        public static Func<FooTable, bool> Prefix(string value)
        {
            return (i) => i.Foo.Substring(0, 5) == value;
        }
        public static Func<FooTable, bool> Suffix(string value) { /* code here */ }
    }
