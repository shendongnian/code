    var parentTask = Task.Factory.StartNew(() =>
    {
        var childTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Inside childTask");
        }, TaskCreationOptions.AttachedToParent);
        var childTask2 = Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000 * 3);
            throw new Exception("Bomb2");
            Console.WriteLine("Inside childTask2");
        }, **TaskCreationOptions.None**);   // If not AttachedToParent, parentTask.Status == RanToCompletion
    }).ContinueWith(t =>
    {
        Console.WriteLine(t.Status);
    });
