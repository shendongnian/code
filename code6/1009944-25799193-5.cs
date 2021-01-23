    public class MyClass
    {
        private string connString;
        private MyClassHelper mySubClass = new MyClassHelper();
        // exec stored procedure 1
        protected class MyClassHelper
        {
            object o = new object();
            // exec stored procedure 2
        }
    }
