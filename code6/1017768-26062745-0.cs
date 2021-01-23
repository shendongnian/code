    public static Task StartNew(Action action, Action<System.Exception> onExceptionCallback = null)
    {
        var actualTask = Task.Factory.StartNew(action);
        AddContinueWithToTask(actualTask, null, onExceptionCallback);
        return actualTask;
    }
    ...
