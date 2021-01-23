        public abstract class A // or interface
        {
           public abstract int x { get; }
        }
        class S
        {
            public A GetA() { return AImplInstead(); }
            class AImpl : A
            {
                // nothing stopping you having a setter on the class
                public override int x { get; set; } 
            }
        }
