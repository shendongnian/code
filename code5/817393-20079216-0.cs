    for (int i = 0; i < 5; i++)
    {
        // var testClient =
        Task.Factory.StartNew(
        () =>
        {
            TaskClient();
        });
    }
    Console.WriteLine("End of program execution.");
