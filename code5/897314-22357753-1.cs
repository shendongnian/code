    // a list of the items we're going to remove
    List<Task> toBeRemoved = new List<Task>();
    // a list of items that are subtasks
    List<Task> subTasks = entities.Where(x => x.ParentTaskId != null).ToList();
    // we will remove anything that has no subtasks and is of type 6.
    toBeRemoved.AddRange(entities.Where(x => x.ParentTaskId == null && x.TypeId == 6 && 
                         subTasks.Count(y => y.ParentTaskId == x.TaskId) == 0));
    // we will remove the tasks which do have subtasks, but no subtasks with a type other than 6
    toBeRemoved.AddRange(entities.Where(x => subTasks.Count(y => y.ParentTaskId == x.TaskId) > 0 && 
                         subTasks.Count(y => y.ParentTaskId == x.TaskId && y.TypeId != 6) == 0));
    // we will remove subtasks that have been 'orphaned'
    toBeRemoved.AddRange(subTasks.Where( y => toBeRemoved.Count(x => x.TaskId == y.ParentTaskId) > 0));
    // now do the actual removal:
    foreach (Task task in toBeRemoved)
    {
        entities.Remove(task);
    }
