    public class HelperClass
    {
        public virtual void HelperMethod()
        { 
            // ...
        }
    }
    
    public class ClassThatUsesHelper
    {
        private readonly HelperClass _helper;
    
        public ClassThatUsesHelper(HelperClass helper)
        {
            _helper = helper;
        }
        public void DoSomething()
        {
            _helper.HelperMethod();
        }
    }
