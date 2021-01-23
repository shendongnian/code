    var resetEvents = new List<AutoResetEvent>();
    for (int i = 0; i < 12; i++)
    {
       var re = new AutoResetEvent(false);
       resetEvents.Add(re);
       ThreadPool.QueueUserWorkItem(w =>
       {
           var threadReset = w as AutoResetEvent;
           var random = new Random();
           try
           {
              // do something.
              Thread.Sleep(random.Next(100, 2000));
           }
           catch (Exception ex)
           {
              // make sure you catch exceptions and release the lock.
              // otherwise you will get into deadlocks
           }
           
           // when ready:
           Console.WriteLine("Done thread " + Thread.CurrentThread.ManagedThreadId);
           threadReset.Set();
        }, re);
    }
    // this bit will wait for all 12 threads to set
    foreach (AutoResetEvent resetEvent in resetEvents)
    {
       resetEvent.WaitOne();
    }
    // At this point, all 12 of your threads have signaled that they're ready.
