    public bool AddTaskTable(int number,string[] params)
        {
            using (dbContext db = new dbContext())
            {
                var t = new Task { blah blah };
                var dbTask = db.Tasks.Add(t);
                try
                {
                    db.SaveChanges();
                    
                   // task id
                   dbTask.taskId;
    
                    return true;
                }
