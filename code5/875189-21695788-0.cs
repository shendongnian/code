    private IObservable<string> GetStrings()
    {
        ReplaySubject<string> results = new ReplaySubject<string>();
        SomeDataObject.ReadyEventHandler ReadyHandler = null;
        SomeDataObject.ErrorEventHandler ErrorHandler = null;
        ReadyHandler += () =>
        {
            for (int i =0; i < dataObject.ItemCount; i++)
                results.OnNext(dataObject[i].ToString());
            
            results.OnCompleted();
        }
        ErrorHandler += ()
        {
            results.OnError(new Exception("oops!"));
        }
        dataObject.Ready += ReadyHandler;
        dataObject.Error += ErrorHandler;
        dataObject.DoRequest();
        return results;
    }
