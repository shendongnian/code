    namespace ThirdPartyLibrary
    {
        public class ThirdPartyLibrary.Quux
        {
            public void Foo() { … }
            …
        }
    }
    namespace YourLibrary
    {
        public sealed class Quux
        {
            private readonly ThirdPartyLibrary.Quux wrapped;
            …
            public Foo() { wrapped.Foo(); }
        }
    }
