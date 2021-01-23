    using Microsoft.Win32.TaskScheduler;
    using (TaskService tasksrvc = new TaskService(server.Name, login, domain, password))
    {
        Task task = tasksrvc.FindTask(taskName);
        task .Run();       
    }
