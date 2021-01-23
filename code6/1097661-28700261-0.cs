    // maximum of 10 items in buffer
    var buffer = new BlockingCollection<NitemonkeyRegistration>(10);
    niteMonkeySales.Subscribe(t => buffer.Add(t), () => buffer.CompleteAdd());
    
    foreach (var item in buffer.GetConsumingEnumerable())
    {
        try
        {
             await SomethingAwaitableWhichCanTakeSeconds(record);
        }
        catch(Exception e)
        {
            // add logging
            // this cancels the loop but also the IObservable
            cancellationTokenSource.Cancel();
            // can't rethrow because line
            // above will cause errored http response already created
        }
    }
