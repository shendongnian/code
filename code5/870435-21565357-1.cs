    class Foo
    {
        public static int Bar = 42;
        public int Baz = 42;
    }
    Console.WriteLine( Foo.Bar ); //OK, static variables don't require the class to be instantiated.
    Console.WriteLine( Foo.Baz ); //Error, Baz is not static.
    Foo foo_instance = new Foo();
    Console.WriteLine( foo_instance.Baz ); //OK
