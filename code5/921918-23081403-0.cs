    public class MyClass
    {
        public class MyPropProxy
        {
            private MyClass c;
            // ctor etc.
            public string this[int index]
            {
                get
                {
                    return c.list[index];
                }
                set
                {
                    c.list[index] = value;
                }
            }
        }
    
        private List<string> list;
        private MyPropProxy myPropProxy;
        // ctor etc.
        public MyPropProxy MyProp
        { 
            get
            {
                return myPropProxy;
            }
        }
    }
