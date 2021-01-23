    // Assembly1
    public static class Constants
    {
        public const string Foo = "Hello";
    }
    // Assembly2
    public class Test
    {
        static void Main()
        {
            Console.WriteLine(Constants.Foo);
        }
    }
