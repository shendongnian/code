    public void MyMethod()
    {
        stopwatch.Start();
        // Any other code here.
        stopwatch.Stop();
 
        //returns longs
        long runningTimeInMs = stopwatch.ElapsedMilliseconds;
    }
