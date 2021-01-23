    query.Select(p => new {
        Id = p.Id,
        TaskIds = p.Tasks.Select(t => t.TaskId)
    })
    .AsEnumerable()  // <-- SQL translation up to here. Anything after is done in-memory
    .Select(p => new DataObject() {
    	Id = p.Id,
    	TaskIds = TaskIds.ToArray()
    })
