        public abstract class MyAbstractClass
        {
            public abstract string Name { get; set; }
            public abstract object[][] Data { get; set; }
        }
        private class MyImpl : MyAbstractClass
        {
            public override string Name { get; set; }
            public override object[][] Data { get; set; }
        }
        private class MyImplBacked : MyAbstractClass
        {
            private string _name;
            public override string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            public override object[][] Data { get; set; }
        }
