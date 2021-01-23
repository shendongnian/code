    public class Foo
    {
        public Foo() : this(new Bar())
        {
        }
        public Foo(Bar bar) // implicit call to parameterless base constructor
        {
            // Do something with bar here
        }
    }
