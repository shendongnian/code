    sealed class FooBuilder
    {
        public TA A { get; set; }
        public TB B { get; set; }
        …
        public Foo Build() { return new Foo(A, B, …); }
    }
    sealed class Foo
    {
        public Foo(TA a, TB b, …)
        {
            … // validate arguments
            this.a = a;
            this.b = b;
            …
        }
        private readonly TA a;
        private readonly TB b;
        …
        public TA A { get { return a; } }
        public TB B { get { return b; } }
        …
    }
