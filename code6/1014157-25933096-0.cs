	var allTasks = new List<Task>();
	RecureseGetTasks(allTasks, DateTime.Now, db);
	//presuming your db is DbContext and .Tasks is List<Task>
	//just change class names
	void RecurseGetTasks(List<Task> allTasks, DateTime dt, DbContext db){
		var tasks = db.Tasks.Where(t=>t.Date.ToString("yyyy-MM-dd") == dt.ToString("yyyy-MM-dd"));
		if (tasks.Count > 0) {
			allTasks.AddRange(tasks.ToList());
			RecurseGetTasks(allTasks, dt.AddDays(-1), db);
		}
	}
