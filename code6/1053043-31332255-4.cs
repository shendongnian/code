    void Main()
    {
        var q = FilteredSource.Generate();
        q.Dump();
    }
    public class FilteredSource
    {
        public static IObservable<string> Generate()
        {           
            var q = from s in OriginalSource.Generate()
                    select s;
            
            return Observable.Create<string>(
                async observer =>
                {           
                    bool produce = false;                
                    try
                    {
                        await q.ForEachAsync(s => {
                                
                            if (s == "start")
                                produce = true;
                                
                            if (s == "end")
                                produce = false;                        
                                
                            if (produce && s != "start")
                                observer.OnNext(s);                        
                        });
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                    }
                    
                    observer.OnCompleted();
                    
                    return Disposable.Empty;
                });
        }
    }
    public class OriginalSource
    {
        public static IObservable<string> Generate()
        {
            return Observable.Create<string>(
                observer =>
                {
                    try
                    {
                        string[] list = {"1", "start", "2", "3", "end", "4", "start", "5", "end"};
                        foreach (string s in list)
                            observer.OnNext(s);
                    }
                    catch (Exception ex)
                    {
                        observer.OnError(ex);
                    }
                    
                    observer.OnCompleted();
                    
                    return Disposable.Empty;
                });
        }            
    }
