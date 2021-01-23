    class Foo
    {
        public static int Bar = 42;
        public void Baz()
        {
            Bar = Bar + 1;
        }
    }
    Console.WriteLine( Foo.Bar ); //42
    Foo foo_instance = new Foo();
    foo_instance.Baz();
    Foo foo_instance2 = new Foo();
    foo_instance2.Baz();
    Console.WriteLine( Foo.Bar ); //44
