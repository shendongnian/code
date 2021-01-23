    YourContext.Tasks
        // Only keep those where it isn't true that it contains no tasks while being type 6
		.Where(t=>!((!t.Tasks.Any()) && t.TypeId == 6))
		// Remove all parents that contains subtasks and only have subtasks with type 6
		.Where(t=>!(t.Tasks.Any() && t.Tasks.All(sub=>sub.TypeId == 6)))
		// Same process on the children, if it has a parent and that parent matches the previous filter
		.Where(t=>!(t.ParentTask != null &&(t.ParentTask.Tasks.Any() && t.ParentTask.Tasks.All(sub=>sub.TypeId == 6))))
