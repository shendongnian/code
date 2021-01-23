    // Note: .Includes removed for brevity's sake.
    var task = Tasks.First(t => t.QaConfigTaskId == 2);
    
    var predicate = PredicateBuilder.True<Task>();
    
    // Ensure that the task's own properties match.
    predicate = predicate.And(t => t.TaskType == task.TaskType &&
          t.Description == task.Description &&
          t.PreTreatment == task.PreTreatment &&
          t.Treatment == task.Treatment);
    
    // HERE'S WHAT CHANGED.
    var query = QueryStructureAnalysisProperty(task.StructureAnalysis);
    predicate = predicate.And(query.Expand());
    Tasks.AsExpandable().Where(predicate).Dump();
