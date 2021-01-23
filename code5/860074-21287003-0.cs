    var tasks = new List<Task>();
    for (int index = 0; index < tests.Count; index/=3)
    {
        var task = Task.Factory.StartNew(() => SomeFunction(tests.GetRange(start, 3)));
        tasks.Add(tasks);
    }
    
    Task.WaitAll(tasks.ToArray());
    MessageBox.Show("Done!");
