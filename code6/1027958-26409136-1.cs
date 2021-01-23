    await BackgroundExecutionManager.RequestAccessAsync();
    if (!taskRegistered)
    {
        Debug.WriteLine("Registering task inside");
        var builder = new BackgroundTaskBuilder();
        builder.Name = exampleTaskName;
        builder.TaskEntryPoint = "Tasks.Upload";
        builder.SetTrigger(new SystemTrigger(SystemTriggerType.TimeZoneChange, false));
        BackgroundTaskRegistration task = builder.Register();
        await new MessageDialog("Task registered!").ShowAsync();
    }
