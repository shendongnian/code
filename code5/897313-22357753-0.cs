    // pull all the sub tasks into a seperate list
    List<Task> subTasks = list.Where(x => x.ParentTaskId != null).ToList();
    list.RemoveAll(x => x.ParentTaskId != null);
    // remove the tasks with type 6 and no subtasks
    list.RemoveAll(x => x.TypeId == 6 && subTasks.Count(y => y.ParentTaskId == x.TaskId) == 0 );
    // remove the tasks which have subtasks, but no subtasks with a type other than 6
    list.RemoveAll(x => subTasks.Count(y => y.ParentTaskId == x.TaskId) > 0 &&
                   subTasks.Count(y => y.ParentTaskId == x.TaskId && y.TypeId != 6) == 0 );
    // remove the 'orphaned' sub tasks
    subTasks.RemoveAll(y => list.Count(x => x.TaskId == y.ParentTaskId) == 0);
    // put the subtasks back in the original list
    list.AddRange(subTasks);
    // sort (if required)
    list.Sort( ... );
