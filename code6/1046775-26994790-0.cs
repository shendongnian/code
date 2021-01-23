    public class Foo
    {
        // A field...
        public static readonly Foo MyFunkyFooField = new Foo(...);
 
        // A property - which could return a field, or create a new instance
        // each time.
        public static Foo MyFunkyFooProperty { get { return ...; } }
    }
