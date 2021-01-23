    private Task task;
    
    public void StartTask()
    {
        if ((task != null) && (task.IsCompleted == false ||
                               task.Status == TaskStatus.Running ||
                               task.Status == TaskStatus.WaitingToRun ||
                               task.Status == TaskStatus.WaitingForActivation))
        {
            Logger.Log("Task has attempted to start while already running");
        }
        else
        {
            Logger.Log("Task has began");
    
            task = Task.Factory.StartNew(() =>
            {
                // Stuff                
            });
        }
    }
