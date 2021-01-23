        [AttributeUsage(AttributeTargets.Property, Inherited = false)]
        public class CalculatedProperty : Attribute
        {
            private string[] _props;
            public CalculatedProperty(params string[] props)
            {
                this._props = props;
            }
            public string[] Properties
            {
                get
                {
                    return _props;
                }
            }
        }
