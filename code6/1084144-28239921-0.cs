    class B : A
        {
            public override int Number { get { return 2; } }
            public new int Foo()
            {
                return base.Number;
            }
        }
