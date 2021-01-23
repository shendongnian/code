    private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
        if (args == null || args.Request == null || args.Request.ApplicationCommands == null)
        {
            return;
        }
    
        var applicationCommands = args.Request.ApplicationCommands;
        var settingsCommands = GetSettingsCommands();
        if (settingsCommands == null) { return; }
        foreach (var settingsCommand in settingsCommands)
        {
            applicationCommands.Add(settingsCommand);
        }
    }
