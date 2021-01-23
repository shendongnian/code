    public async Task<ActionResult> KPI(int id = 0)
    {
        ViewData["ontime"] = await getOnTimeTasksAsync(id);
        ViewData["ictasks"] = await getLateTasksAsync(id);
        ViewData["incomplete"] = await getIncompleteTasksAsync(id);
        return View();
    }
    public Task<int> getOnTimeTasksAsync(int id)
    {
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
    public Task<int> getLateTasksAsync(int id)
    {
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
    public Task<int> getIncompleteTasksAsync(int id)
    {
        return db.Tasks.Include(t => t.Job).Where(...).CountAsync();
    }
