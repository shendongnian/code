    public class Foo
    {
        public Foo()
        {
            // do something
        }
    }
    public class SuperFoo : Foo
    {
        public SuperFoo() : base() // call the Foo constructor - you do not have to call base explicitely, just a more verbose example
        {
            // do something else
        }
    }
