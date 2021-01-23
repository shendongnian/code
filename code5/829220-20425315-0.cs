    public class MyClass
    {
        public int start {get;set;};
        public int end {get;set;};
        public int[] arr {get;set;};
    }
    public void Thread2(object parameter)
    {
        MyClass obj = (MyClass)parameter;
        //Make use of obj
    }
    HisThread thr2 = new HisThread();
    Thread tid2 = new Thread(new ParameterizedThreadStart(thr2.Thread2));
    tid2.Start(new MyClass{...});
