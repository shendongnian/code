    public class MyClass
    {
        public MyClass(string[] strings, double[] doubles)
        {
            this.Strings = strings;
            this.Doubles = doubles;
        }
        public string[] Strings {get;set;}
        public double[] Doubles {get;set;}
    }
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        MyClass result = new MyClass(new string[] {"a", "b"}, new double[] {1d, 2d});
        e.Result = result;
    }
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      MyClass result = (MyClass)e.Result;
      // process further
    }
