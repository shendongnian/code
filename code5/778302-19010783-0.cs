    internal static void GetData1()
    {
        // Start the tasks
        List<Task<Data>> dataTasks = new List<Task<Data>>();
        for (int item = 0; item < TotalItems; item++)
        {
            dataTasks.Add(Task.Run(() => MyAyncMethod(State[item])));
        }
        // Wait for them all to complete
        Task.WaitAll(dataTasks);
    }
