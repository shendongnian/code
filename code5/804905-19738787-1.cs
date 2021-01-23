    Task task = null;
    var PendingTasks = 
        session.QueryOver<Task>(() => task)
        // the WHERE clause: OrderId IN (subquery)
        .WithSubquery
        .WhereProperty(() => task.OrderId)
        .In(subQuery)
        // the rest of your SELECT/projections and transformation
        .SelectList(list => list
            .SelectGroup(b => b.OrderId)
            .Select(b => b.TaskType)
        )         
        .TransformUsing((Transformers.AliasToBean<TaskType>()))
        .List<TaskType>()
        ;
