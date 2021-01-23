    async public void ParseAll(List<Site> SiteList)
    {
        while (true)
        {
            List<Task<Site>> TaskList = new List<Task<Site>>();
    
            foreach(Site s in SiteList)
            {
                TaskList.Add(s.ParseData());
            }
    
            await Task.WhenAny(TaskList);
            TaskList = TaskList.Select(t => t.IsCompleted ? t.Result.ParseData() : t).ToList();
        }
    }
