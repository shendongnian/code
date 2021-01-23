    public async Task<ActionResult> KPI(int id = 0)
    {
        var results = await Task.WhenAll(getOnTimeTasksAsync(id),
            getLateTasksAsync(id), getIncompleteTasksAsync(id));
        ViewData["ontime"] = results[0];
        ViewData["ictasks"] = results[1];
        ViewData["incomplete"] = results[2];
        return View();
    }
    public Task<int> getOnTimeTasksAsync(int id)
    {
        var db = new MyDatabaseContext();
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
    public Task<int> getLateTasksAsync(int id)
    {
        var db = new MyDatabaseContext();
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
    public Task<int> getIncompleteTasksAsync(int id)
    {
        var db = new MyDatabaseContext();
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
