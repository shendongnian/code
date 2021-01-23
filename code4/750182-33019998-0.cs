    public JsonResult taskCount(string fDate)
    {
      // do some stuff based on the date
      // totalTasks is a count of the things I need to do today
      // tasksDone is a count of the tasks I actually did
      // pcDone is the percentage of tasks done
	
      return Json(new {
        totalTasks = totalTasks,
        tasksDone = tasksDone,
        percentDone = pcDone
      });
    }
