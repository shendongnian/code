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
            new Thread(this.rocess).Start(task);
        }
    }
