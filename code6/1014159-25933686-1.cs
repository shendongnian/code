    // in-memory cache of all tasks in reverse chronological order (starting from today): 
    Task[] tasks = db.Tasks.Where(task => task.Date <= DateTime.TodayUtc)
                           .OrderByDescending(task => task.Date)
                           .ToArray(); // see note below for reasons why this is necessary
    var oneDay = TimeSpan.FromDays(1);
