    public class Foo
    {
        // Not valid: constructors can't be generic. But imagine...
        public Foo<T>(T initializationValue)
        {
            // Note that this isn't constructing a Foo<T> -
            // Foo is a non-generic type. It's only the constructor
            // that is generic.
        }
    }
