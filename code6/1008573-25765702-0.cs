    List<Task> tasks = new List<Task>();
    for (int i = 0; i != 1000; ++i)
    {
      Task task = DoMyOperationAsync();
      tasks.Add(task);
    }
    await Task.WhenAll(tasks);
