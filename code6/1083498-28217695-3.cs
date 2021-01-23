        public class Foo
        {
            private int _a = 0;
            public int BAR { get { return _a; } set { _a = value; } }
        }
        public class AddNode
        {
            private Foo NodeName;
            public AddNode(ref Foo ANodeName)
            {
                NodeName = ANodeName;
                NodeName.BAR = 30;
            }
        }
