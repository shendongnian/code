    public class Foo
    {
        public static implicit operator Foo(string value)
        {
            Console.WriteLine("implicit");
            return null;
        }
        public static explicit operator Foo(string value)
        {
            Console.WriteLine("Explicit");
            return null;
        }
    }
