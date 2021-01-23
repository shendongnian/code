    List<Tasks> tasks = new List<Tasks>();
    for (int i = 0; i < 20; i++)
    {
        var task = Task.Run(() => DoUpload(i));
        tasks.Add(task);
    }
    //wait for completion of all tasks
    Task.WaitAll(tasks.ToArray());
