    public class Foo
    {
        public void Bar() { Console.WriteLine("Bar() called: {0}", string.Empty); }
        public void Bar(int i) { Console.WriteLine("Bar(int) called: {0}", i); }
        public void Bar(double d) { Console.WriteLine("Bar(double) called: {0:N4}", d); }
        public void Bar(int i, string s) { Console.WriteLine("Bar(int, string) called: {0} & {1}", i, s); }
        public void Bar(double d, string s) { Console.WriteLine("Bar(double, string) called: {0:N4}, {1}", d, s); }
    }
