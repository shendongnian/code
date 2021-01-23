        class A
        {
            public int x { get; protected set; }
        }
        class S : A
        {
            public A GetA() { return this; } //or something like that.
        }
