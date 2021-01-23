    // On UI Thread you can call something like this:
    Task.Factory.StartNew(DoWork);
    // You can take use CancellationToken in order to support cancellation.
    // You also can use other overloads of the method, in order to
    // obtain required behavior.
    // You also can have the Value property, which will denote how much records was proceeded.
    // This property you can bound with ProgressBar, and update it properly
  
    public void DoWork()
    {
        var myOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };
        Parallel.For(0, NumberOfClients, myOptions, i=>
        { 
            ThirdPartyLibrary Instance = new Instance(SSN[i]);
            Instance.Run();
            Interlocked.Increment(ref value);
            RaisePropertyChanged("Value");
        });
    }
