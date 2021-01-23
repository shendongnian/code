    [OhMy]
    public class Class2 : ContextBoundObject
    {
        private string one = "1";
        public void Method1()
        {
            var nc = new NestedClass(this);
        }
        public class NestedClass
        {
            public NestedClass(Class2 c2)
            {
                Console.WriteLine(c2.one);  // Note: nested classes are allowed access to outer classes privates
            }
        }
    }
    static void Main(string[] args)
    {
        var c2 = new Class2();
        // This call causes no problems:
        c2.Method1();
        // This, however, causes the issue.
        var nc = new Class2.NestedClass(c2);
    }
