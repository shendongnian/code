    var queue = new BlockingCollection<string>(new ConcurrentQueue<string>());
    var producer = Task.Factory.StartNew(() =>
    {
        queue.Add("Hello!");
        Thread.Sleep(1000);
        queue.Add("World!");
        Thread.Sleep(2000);
        Enumerable.Range(0, 100).ToList().ForEach(x => queue.Add(x.ToString()));
        queue.CompleteAdding();
    });
    var consumer = Task.Factory.StartNew(() =>
        {
            while (!queue.IsCompleted)
            {
                try
                {
                    Debug.WriteLine(queue.Take());
                }
                catch (InvalidOperationException)
                {
                }
            }
        });
    Task.WaitAll(producer, consumer);
