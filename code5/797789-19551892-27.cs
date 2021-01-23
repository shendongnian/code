    // A asynchronous function representing the REST call
    public IObservable<string> SomeRestCall(int x)
    {
        return x % 2 == 0
            ? Observable.Throw<string>(new Exception())
            : Observable.Return(x + "-ret").Delay(TimeSpan.FromSeconds(1));   
    }
