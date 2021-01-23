    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        // Windows Phone app must call this to use trigger types (see MSDN)
        await BackgroundExecutionManager.RequestAccessAsync();
        BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = "First Task", TaskEntryPoint = "myTask.FirstTask" };
        taskBuilder.SetTrigger(new TimeTrigger(15, true));
        BackgroundTaskRegistration myFirstTask = taskBuilder.Register();
    }
