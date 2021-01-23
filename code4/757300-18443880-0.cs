    public class CoolClass {
        public string MyProperty { get; private set; }
        public string MyOtherProperty { get; private set; }
    
        private CoolClass(string myProperty, string myOtherProperty) {
            MyProperty = myProperty;
            MyOtherProperty = myOtherProperty;
        }
    
        public static CoolClass CreateNew(string myProperty, string myOtherProperty) {
            return new CoolClass(myProperty, myOtherProperty);
        }
    }
