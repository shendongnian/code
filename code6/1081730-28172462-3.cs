    // Note: .Includes removed for brevity's sake.
    var task = Tasks.First(t => t.QaConfigTaskId == 2);
    
    var predicate = PredicateBuilder.True<Task>();
    
    // Ensure that the task's own properties match.
    predicate = predicate.And(t => t.TaskType == task.TaskType &&
          t.Description == task.Description &&
          t.PreTreatment == task.PreTreatment &&
          t.Treatment == task.Treatment);
    
    var structureAnalysis = task.StructureAnalysis;
    var query = PredicateBuilder.True<StructureAnalysis>();
    query = query.And(analysis =>
    		// The names match
    		analysis.Name == structureAnalysis.Name &&
    		// We have the same # of goals so they must all match.
    		analysis.Goals.Count == structureAnalysis.Goals.Count
    	);
	
    //// HERE'S WHAT'S NEW ////
    Expression<Func<Task, bool>> subPredicate = t => query.Invoke(t.StructureAnalysis);
    
    predicate = predicate.And(subPredicate.Expand());
    
    Tasks.AsExpandable().Where(predicate).Dump();
