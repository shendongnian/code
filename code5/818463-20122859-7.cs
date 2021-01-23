    var collection = new ObservableCollection<string>();
    Func<string, Task> addAction = x =>
        {
            Console.WriteLine("Begin add task for " + x);
            return Task.Delay(2000)
                    .ContinueWith(t => Console.WriteLine("End add task for " + x));
        };
    Func<string, Task> removeAction = x =>
    {
        Console.WriteLine("Begin remove task for " + x);
        return Task.Delay(3000)
                .ContinueWith(t => Console.WriteLine("End remove task for " + x));
    };
    var sub = HandleAddRemove(
        collection,
        addAction,
        removeAction);
    collection.Add("item1");
    Thread.Sleep(1000);
    collection.Remove("item1");
    Thread.Sleep(1000);
    collection.Add("item2");
    collection.Add("item3");
    Thread.Sleep(5000);
    collection.Remove("item3");
    Thread.Sleep(1000);
    collection.Remove("item2");
    Thread.Sleep(30000);
    Console.WriteLine("Done");
            
    sub.Dispose();
