        using (var ctx = DbContextManager<StoreDataContext>.GetManager())
        {
            var task = new Task();
            WriteNonKeyData(task, item);
            ctx.DbContext.Tasks.Add(task); // task.TaskType null
            ctx.DbContext.SaveChanges(); // task.TaskType still null
            // let ef create a proxy for the very same database object
            var ptask = ctx.DbContext.Tasks.First( p => p.ID == task.ID );
            // ptask.TaskType is now available as the actual type of
            // ptask is not Task but rather a TaskProxy that inherits from Task
            // and is created automatically by ef
            return ReadData(ptask);
        }
