    void Main()
    {
        PlainRxCountExample();
    }
    
    private void PlainRxCountExample()
    {
        IObservable<int> countResult = StreamWith5Elements().Count();
        countResult.Subscribe(count => Console.WriteLine(count));
        /* block until completed for the sake of the example */
        countResult.Wait();
    }
