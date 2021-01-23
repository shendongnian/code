    public class HelperFoo
    {
        public static Func<FooTable, bool> Prefix(string value)
        {
            return (i) => i.Foo.Substring(0, 5);
        }
        public static string Suffix(string value) { /* code here */ }
    }
