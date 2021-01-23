    var tasks = new Task[5];
    for (int i = 0; i < 5; i++)
    {
        // var testClient =
        tasks[i] = Task.Factory.StartNew(
                    () =>
                    {
                        TaskClient();
                    });
    }
    Task.WaitAll(tasks);
