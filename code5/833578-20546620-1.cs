        private class MyImplBacked : IMyInterface
        {
            private string _name;
            public string Name
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
            public object[][] Data { get; set; }
        }
