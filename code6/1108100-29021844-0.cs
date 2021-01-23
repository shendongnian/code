    var tasks = new List<Task>();
    for (int i = 0; i < pageCount; i++)
    {
        var localCurrentPage = currentPage; 
        var task = Task.Run(() =>
        {
            worker.GetHouses(localCurrentPage);
        });
        tasks.Add(task);
        currentPage++;
    }
    Task.WaitAll(tasks.ToArray());
