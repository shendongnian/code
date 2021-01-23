    Console.WriteLine("***Starting T1");
    //run two tasks sequentially
    Task<Task> t = FirstTask().ContinueWith(_ => SecondTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
    
    //register succeded and faulted continuations
    t.Unwrap().ContinueWith(_ => Completion(), TaskContinuationOptions.OnlyOnRanToCompletion);
    t.Unwrap().ContinueWith(_ => Faulted(), TaskContinuationOptions.OnlyOnFaulted);
    Console.ReadLine();
    Console.WriteLine("***Starting T2");
    Task<Task> t2 = FirstTask().ContinueWith(_ => FaultTask(), TaskContinuationOptions.OnlyOnRanToCompletion);
    t2.Unwrap().ContinueWith(_ => Completion(), TaskContinuationOptions.OnlyOnRanToCompletion);
    t2.Unwrap().ContinueWith(_ => Faulted(), TaskContinuationOptions.OnlyOnFaulted);
    Console.ReadLine();
