    static Task FromExAsync(Exception ex) 
    {
        var ei = System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(ex);
        var task = new Task(() => { ei.Throw(); });
        task.RunSynchronously();
        return task;
    }
