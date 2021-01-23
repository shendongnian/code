    var commandLineArgs = Environment.GetCommandLineArgs();
    var taskName = commandLineArgs[1];
    // Locate the action to execute for the task
    Action<string[]> action;
    if(!commands.TryGetValue(taskName, out action))
    {
        throw new NotSupportedException("Task not found");
    }
    // Pass only the remaining arguments
    var actionArgs = new string[commandLineArgs.Length-2];
    commandLineArgs.CopyTo(actionArgs, 2);
    // Actually invoke the handler
    action(actionArgs);
