    public class CompositeFunctionality
    {
        public void MyMethod1(string input)
        {
            // Doing stuff here
        }
    }
    public class BaseClass
    {
        private CompositeFunctionality composite = new CompositeFunctionality();
        public void MyMethod2(string input)
        {
            // this is accessible in the base class
            composite.MyMethod1();
        }
    }
    public class DerivedClass : BaseClass
    {
        public void MyMethod3(string input)
        {
             // do whatever you want
             // but composite is not accessible here
        }
    }
