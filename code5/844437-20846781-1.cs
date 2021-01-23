        // This MyClass code goes into a MyClass.cs file
        public partial class MyClass
        {
            private int fieldA;
    
            private string fieldB;
    
            private decimal fieldC;
    
            public MyClass(int a, string b, decimal c)
            {
                this.fieldA = a;
                this.fieldB = b;
                this.fieldC = c;
            }
        }
    
        // This additional code for MyClass goes into a
        // separate MyClass.debug.cs file
    #if DEBUG
    
        partial class MyClass : IDebugAccessible
        {
            public IDebugAccessor GetDebugAccessor()
            {
                return new DebugAccessor(this);
            }
    
            // The MyClass.DebugAccessor nested class has access to
            // private members of MyClass.
            private class DebugAccessor : IDebugAccessor
            {
                private Dictionary<string, object> values;
    
                public DebugAccessor(MyClass instance)
                {
                    this.values = new Dictionary<string, object>
                    {
                        { "fieldA", instance.fieldA },
                        { "fieldB", instance.fieldB },
                        { "fieldC", instance.fieldC },
                    };
                }
    
                public IEnumerable<KeyValuePair<string, object>> Values
                {
                    get { return this.values; }
                }
            }
        }
    
    #endif
    
        // The intention behind creating these interfaces is to define
        // a standard way to access values from different types
        // for debugging purposes.  This is just a simple example.
        // These interfaces would go into their own .cs file.
        public interface IDebugAccessor
        {
            IEnumerable<KeyValuePair<string, object>> Values { get; }
        }
    
        public interface IDebugAccessible
        {
            IDebugAccessor GetDebugAccessor();
        }
