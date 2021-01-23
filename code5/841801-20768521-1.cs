        public class NestedClassB 
        {
            private readonly Dictionary<int, NestedClassA> _PassedDictionary;
            public NestedClassB() { }
            public NestedClassB(Dictionary<int, NestedClassA> tempDic) {
                _PassedDictionary = tempDic;
            }
            public Dictionary<int, NestedClassA> PassedDictionary {
                get { return _PassedDictionary; }
            }
        }
