    private void updateTreeView()
    {   
        treeActiveTasks.BeginUpdate();    
        treeActiveTasks.Nodes.Clear(); 
        foreach (var task in m_user.Tasks)
        {
            if (!task.IsComplete)
            {
                var taskNode = treeActiveTasks.Nodes.Add(task.Title);
                foreach (var subtask in task.Subtasks)
                    if (!subtask.IsComplete)
                        taskNode.Nodes.Add(subtask.Title);
            }               
        }
        treeActiveTasks.EndUpdate();
    }
