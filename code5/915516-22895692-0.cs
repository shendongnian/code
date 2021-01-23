    public class Main
    {
        public void MyProcess(Action<object> toMethod, object result)
        {
            // do some fancy stuff and send it to callback object       
            toMethod(result);
        }
    }
    public class Something
    {
        public void RunMethod()
        {
            object result = new object();
            MyProcess(Method1, result);
            MyProcess(Method2, result);
        }
        private void Method1(object result)
        {
            // do stuff for this callback
        }
        private void Method2(object result)
        {
            // do stuff for this callback
        }
    }
