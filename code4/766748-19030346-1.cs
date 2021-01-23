    private void SetParent(WorkflowContext context, WorkflowTask task)
        {
            if (task.ParentTask != null && task.ParentTask.WorkflowTaskId != 0)
            {
                var parentTask = context.WorkflowTasks.Where(t => t.WorkflowTaskId == task.ParentTask.WorkflowTaskId).FirstOrDefault();
                var parent = parentTask as ParentTask;
                task.ParentTask = parent;
                if (parentTask is ContainerTask)
                {
                    var container = context.ContainerTasks.Where(c => c.WorkflowTaskId == parentTask.WorkflowTaskId).Include(c => c.ChildTasks).FirstOrDefault() as ContainerTask;
                    if (container.ChildTasks == null)
                        container.ChildTasks = new List<WorkflowTask>();
                    var childTask = container.ChildTasks.Find(t => t.WorkflowTaskId == task.WorkflowTaskId
                                                                    && t.Order == task.Order);
                    if(childTask == null)
                        container.ChildTasks.Add(task);
                }
            }
        }
