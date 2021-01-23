    public class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass() : base(myProperty: "abc") { }
    }
    
    public class MyBaseClass
    {
        public string MyProperty { get; private set; }
    
        public MyBaseClass(string myProperty) { 
            this.MyProperty = myProperty;
        }
    }
