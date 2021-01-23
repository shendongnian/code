    var taskEntities = from t in DB.Tasks
    					orderby t.EntryDate descending
    					select t;
    var tasks = new List<TaskList.Models.Task>();
    foreach(var taskEntity in taskEntities)
    {
    	tasks.Add(new TaskList.Models.Task()
    				{
    				   Id = t.Id,
    				   Task1 = t.Task1,
    				   IsCompleted = t.IsCompleted,
    				   EntryDate = t.EntryDate
    				});
    }
    return View(tasks);
