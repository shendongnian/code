    while (!Quitting && TaskQueue.Any())
    {
        foreach (var task in TaskQueue.ToArray())
        {
            if (Quitting || task.Code == TaskCode.Quit)
            {
                Quitting = true;
                return;
            }
            if (!task.Runnable)
            {
                continue;
            }
            var thread = new Thread(state =>
            {
                var taskState = (Task)state;
                try
                {
                    taskState.Callback();
                }
                catch (Exception e)
                {
                    if (taskState.Error != null)
                    {
                        taskState.Error(e);
                    }
                }
            });
            thread.Start(task);
        }
    }
