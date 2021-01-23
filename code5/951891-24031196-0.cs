    class MyResult //Name the classes and properties accordingly
    {
        public string[] Strings {get; set;}
        public double[] Doubles {get; set;}
    }
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        //Do work..
        e.Result = new MyResult {Strings =..., Doubles  = ...  };
    }
    
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        MyResult result = (MyResult)e.Result;
        //Do whatever with result
    }
