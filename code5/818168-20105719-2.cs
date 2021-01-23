    class DerivedTimer : System.Timers.Timer
    {
        public string Foo { get; set; }
    }
    myTimer = new DerivedTimer();
    myTimer.Interval = 3000;
    public void methodRunRegularly(int var1){
        myTimer.Foo = "Foobar!";
        myTimer.Elapsed += doSomething;
        myTimer.Start();
    }
    public void doSomething(object sender, EventArgs e)
    {
        var t = (DerivedTimer)sender;
        var foo = t.Foo;
        // do processing
    }
