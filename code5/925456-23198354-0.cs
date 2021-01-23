    public int AddTaskTable(int number,string[] params)
        {
            using (dbContext db = new dbContext())
            {
                var t = new Task { blah blah };
                db.Tasks.Add(t);
                try
                {
                    db.SaveChanges();
                    var newTaskId = dbContext
                                        .Tasks
                                        .OrderByDescending(x => x.TaskId)
                                        .FirstOrDefault().TaskId;
                    return newTaskId;
                 }
             }
        }
