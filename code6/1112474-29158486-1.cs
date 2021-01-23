        abstract class Base
        {
            public int val { get; set; }
            public virtual Base Inc() { return null; }
        }
        class A : Base
        {
            public override Base Inc()
            {
                return new A { val = val + 1 };
            }
        }
        class B : A
        {
            public override Base Inc()
            {
                return new B { val = val + 2 };
            }
        }
