    var tasks = new List<Task>();
    for (int i = 0; i < pageCount; i++)
    {
        var currentPageCopy = currentPage; 
        var task = Task.Run(() =>
        {
            worker.GetHouses(currentPageCopy);
        });
        tasks.Add(task);
        currentPage++;
    }
    Task.WaitAll(tasks.ToArray());
