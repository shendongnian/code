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
        public sealed class Quux // has same methods as the third-party library's
        {                        // type
            private readonly ThirdPartyLibrary.Quux wrapped;
            …
            public Foo() { wrapped.Foo(); } // forward calls to the underlying type
        }
    }
