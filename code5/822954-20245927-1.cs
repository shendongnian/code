    public sealed class Foo //3rd party sealed class
    { ... }
    public class FooWrapper
    {
        public long FooId {get; set;}
        public Foo InnerFoo {get; set;} 
    }
