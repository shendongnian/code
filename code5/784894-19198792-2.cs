    private Task task;
    
    public void StartTask()
    {
        if ((task != null) && (task.IsCompleted == false ||
                               task.Status == TaskStatus.Running ||
                               task.Status == TaskStatus.WaitingToRun ||
                               task.Status == TaskStatus.WaitingForActivation))
        {
            Logger.Log("Task is already running");
        }
        else
        {
            task = Task.Factory.StartNew(() =>
            {
                Logger.Log("Task has been started");
                // Do other things here               
            });
        }
    }
