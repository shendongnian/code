    private void updateTreeView()
    {   
        treeActiveTasks.BeginUpdate();    
        treeActiveTasks.Nodes.Clear();
        treeActiveTasks.Nodes.AddRange(
            (from task in m_user.Tasks
             where !task.IsComplete
             select new TreeNode(
                 task.Title,
                 (from subtask in task.Subtasks
                  where !subtask.IsComplete
                  select new TreeNode(subtask.Title)
                 ).ToArray())
            ).ToArray());
        treeActiveTasks.EndUpdate();
    }
