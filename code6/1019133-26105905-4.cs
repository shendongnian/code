        class FooBuilder // mutable version used to prepare immutable objects
        {
            public int X { get; set; }
            public List<string> Ys { get; set; }
            public Foo Build()
            {
                return new Foo(x, ys);
            }
        }
        class Foo // immutable version
        {
            public Foo(int x, List<string> ys)
            {
                this.x = x;
                this.ys = new List<string>(ys); // create a copy, don't use the original
            }                                   // since that is beyond our control
            private readonly int x;
            private readonly List<string> ys;
            …
        }
