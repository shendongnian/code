    public static class HelperClass
    {
        public static void HelperMethod()
        { 
            // ...
        }
    }
    
    public class ClassThatUsesHelper
    {
        public void DoSomething()
        {
            HelperClass.HelperMethod();
        }
    }
