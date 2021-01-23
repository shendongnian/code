    var taskEntities = from t in DB.Tasks
    					orderby t.EntryDate descending
    					select t;
    var tasks = new List<TaskList.Models.Task>();
    foreach(var taskEntity in taskEntities)
    {
    	tasks.Add(new TaskList.Models.Task()
    				{
    				   Id = taskEntity.Id,
    				   Task1 = taskEntity.Task1,
    				   IsCompleted = taskEntity.IsCompleted,
    				   EntryDate = taskEntity.EntryDate
    				});
    }
    return View(tasks);
