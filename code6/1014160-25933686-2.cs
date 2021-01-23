    var today = DateTime.Today;
    var oneDay = TimeSpan.FromDays(1);
    // in-memory cache of all tasks in reverse chronological order (starting from today): 
    Task[] tasks = db.Tasks.Where(task => task.Date <= today)
                           .OrderByDescending(task => task.Date)
                           .ToArray(); // see note below for reasons why this is necessary
