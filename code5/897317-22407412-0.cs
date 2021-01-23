        var parents = tasks.Where(task => task.SubTasks.Any());
        var tasksWithNoSubs = tasks.Where(task => !task.SubTasks.Any());
        var parentIdsToRemove = new List<int?>();
        var childIdsToRemove = new List<int?>();
        foreach (var parent in parents)
        {
            var children = tasks.Where(task => task.ParentTaskID == parent.Id);
            if (children.All(task => task.StatusId == 6))
            {
                parentIdsToRemove.Add(parent.Id); //mark this parent for removal
                childIdsToRemove.AddRange(Enumerable.Select(children.Select(child => child.Id), dummy => (int?) dummy));
            }
        }
        //get all Tasks that have NO Subtasks and also have a StatusID = 6
        parentIdsToRemove.AddRange(Enumerable.Select((from task in tasksWithNoSubs where task.StatusId == 6 select task.Id), dummy => (int?) dummy));
        //get a list of children with an Id contained in the list parentIdsToRemove
        var tasksToRemove =
            tasks.Where(task => parentIdsToRemove.Contains(task.Id) || childIdsToRemove.Contains(task.Id));
        //remove the tasks from the collection
        tasks = tasks.Where(task => !tasksToRemove.Contains(task));
