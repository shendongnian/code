    ((from a in context.Tasks).AsEnumerable().Select(t => new TaskSearch
    {
      TaskID = t.TaskID,
      TaskTypeName = Enum.GetName(typeof(TaskTypeEnum), t.TaskType)
      
    }).ToList();
