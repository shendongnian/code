        public class X
        {
            public X()
            {
                Y = new List<Y>();
            }
            public List<Y> Y { get; private set; }
        }
        public class Y
        {
            public Y()
            {
                Z = new List<Z>();
            }
            public int A { get; set; }
            public List<Z> Z { get; private set; }
        }
        public class Z
        {
            public int V { get; set; }
        }
