        public class FooComparer : IEqualityComparer
        {
            public bool Equals(Foo x, Foo y)
            {
                if (x.A == y.A && x.B == y.B)
                {
                    return true;
                }
                return false;
            }
            public int GetHashCode(Foo inst)
            {
                return inst.GetHashCode();
            }
        }
