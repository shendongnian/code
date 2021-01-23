    Task.WhenAll(allTasks).ContinueWith((t) =>
    {
        if(t.RanToCompletion)
        {
            MyBlockingCollection.CompleteAdding();
        }
        else
        {
            Console.WriteLine(t.Exception);
        }
    });
