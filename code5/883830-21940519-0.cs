    //Clear before entry
        treeActiveTasks.Nodes.Clear(); 
        treeActiveTasks.BeginUpdate();
        int parentCount = 0;
        
        //Update tasks
        foreach (Task task in m_user.Tasks)
        {
            if (!task.IsComplete)
            {
                treeActiveTasks.Nodes.Add(task.Title); 
                
                int i = 0;
                foreach (Subtask subtask in task.Subtasks)
                {
                    if (!subtask.IsComplete)
                    {
                        treeActiveTasks.Nodes[parentCount].Nodes.Add(subtask.Title);
                    }
                    i++;
                }
                parentCount++;
            }
        }
        treeActiveTasks.EndUpdate();
