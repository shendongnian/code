    List tasks = new List();
    for (int i = 0; i < 5; i++)
    {
      tasks.Add(ProcessAsync(token));
    }
    await Task.WhenAll(tasks);
