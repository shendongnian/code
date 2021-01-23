    public class MyClass : MyBaseClass
    {
        private int myField;
        public override int MyProperty
        {
            get { return myField; }          
        }
        private int MyPropertySetter
        {
            set { myField = value; }
        }
    }
