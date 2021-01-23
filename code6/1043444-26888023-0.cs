        public class SecondObject : FirstObject
        {
            private string _stringProp;
            public string StringProp {
                get { return _stringProp; }
                set
                {
                    _stringProp = value;
                    DecimalProp = Convert.ToDecimal(value);
                }
            }
        }
