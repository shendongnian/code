    public class BaseClass
    {
        protected readonly string friendlyName;
    
        public string FriendlyName {
            get {
                return friendlyName;
            }
        }
    }
    
    public class DerivedClassOne : BaseClass {
        public DerivedClassOne() {
            friendlyName = "A super duper derived class";
        }
    }
    
    public class DerivedClassTwo : BaseClass {
        public DerivedClassOne() {
            friendlyName = "Yet another derived class";
        }
    }
