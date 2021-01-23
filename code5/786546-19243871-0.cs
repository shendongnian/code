    using Microsoft.Win32.TaskScheduler;
    using (TaskService ts = new TaskService(server.Name, login, domain, password)
    {
        Task t = ts.FindTask(taskName);
        t.Run()
    }
