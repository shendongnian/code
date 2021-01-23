    public class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass()
        {
            // Want to allow MyProperty to be set from this class but not
            // set publically
            MyProperty = "abc";
        }
    }
    public class MyBaseClass
    {
        public string MyProperty { get; protected set; }
    }
