    List<Task> tt = new List<Task>();
    for (int i = 0; i < 5; i++)
    {
        int temp = i;
        tt.Add(
        new Task( () =>
        {
            Thread.Sleep(temp * 1000);
            Console.Write("end! ");
        }));
    }
    
    tt.ForEach(t => t.
    Start());
    Task.WaitAll(tt.ToArray());
