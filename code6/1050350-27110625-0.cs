    public class A
    {
        public A (string foo)
        {
            Console.WriteLine(foo);
        }
        public A () : this("foo bar")
        {}
    }
