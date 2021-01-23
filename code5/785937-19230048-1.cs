    public class Program
    {
        private static void Main(string[] args)
        {
            DynamicClass dynamicClass = new DynamicClass();
            dynamicClass.Property["Test"] = 1;
            dynamicClass.Property["test2"] = "foo";
            Debugger.Break();
        }
    }
    
    [DebuggerTypeProxy(typeof(DynamicClassProxy))]
    public class DynamicClass
    {
        // property is a class that will create dynamic properties at runtime
        private DynamicProperty _property = new DynamicProperty();
        public DynamicProperty Property
        {
            get { return _property; }
            set { _property = value; }
        }
        [DebuggerDisplay("{value}", Name = "{key}")]
        private class KeyValuePair
        {
            private string key;
            private object value;
            public KeyValuePair(KeyValuePair<string,object> kvp)
            {
                this.value = kvp.Value;
                this.key = kvp.Key;
            }
        }
        private class DynamicClassProxy
        {
            private DynamicClass _dynamicClass;
            public DynamicClassProxy(DynamicClass dynamicClass)
            {
                _dynamicClass = dynamicClass;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public KeyValuePair[] Keys
            {
                get
                {
                    return _dynamicClass.Property.properties.Select(x => new KeyValuePair(x)).ToArray();
                }
            }
        }
        public class DynamicProperty
        {
            //Make it so no one can create these objects.
            internal DynamicProperty() { }
            // a Dictionary that hold all the dynamic property values
            internal Dictionary<string, object> properties = new Dictionary<string, object>();
            // the property call to get any dynamic property in our Dictionary, or "" if none found.
            public object this[string name]
            {
                get
                {
                    if (properties.ContainsKey(name))
                    {
                        return properties[name];
                    }
                    return "";
                }
                set
                {
                    properties[name] = value;
                }
            }
        }
    }
