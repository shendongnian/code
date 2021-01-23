    public class BaseClass
    {
        public virtual void MyMethod1(string input)
        {
            // Doing stuff here
        }
        public void MyMethod2(string input)
        {
            // Doing stuff here
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void MyMethod1(){..}
    
        /// MyMethod2 is not overridable
    }
