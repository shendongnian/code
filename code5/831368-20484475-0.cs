    public void DoingSomethingTest()
    {
        var done = new ManualResetEvent(false); // initially not set
        //Setup
        //Doing some setup here.
        target.SomethingDone += (sender, args) =>
            {
                done.Set();
            };
        //Exercise
        target.DoSomething(_someParameter);
        done.WaitOne(); // waits until Set is called. You can specify an optional timeout too which is nice
        //Verify
        //Doing some asserts here.
    }
