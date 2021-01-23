        object[] objs = new object[10];
        List<Task> tasks = new List<Task>();
        foreach (object o in objs)
        {
            // method needs to process ASAP
            var localObj = o;
            tasks.Add(Task.Factory.StartNew(() => StartProcessing(localObj)));
        }
        try
        {
            Task.WaitAll(tasks.ToArray());
        }
        catch (AggregateException ae)
        {
            // handle the exceptions
        }
