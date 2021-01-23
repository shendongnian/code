    public static void Main(string[] args)
    {
        Task task1 = Task.Run(() => ProcessAccount1()),
            task2 = Task.Run(() => ProcessAccount2()),
            task3 = Task.Run(() => ProcessAccount3());
        Task.WaitAll(task1, task2, task3);
    }
