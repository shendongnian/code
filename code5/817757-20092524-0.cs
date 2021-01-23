    public abstract class Foo
    {
        static Foo()
        {
            Console.Write("4");
        }
    
        protected internal static void Baz()
        {
            // I don't do anything but am called in inherited classes' 
            // constructors to call the Foo constructor
        }
    }
    
    public class Bar : Foo
    {
        static Bar()
        {
            Foo.Baz();
            Console.Write("2");
        }
    
        public static void DoSomething()
        {
            /*...*/
        }
    }
