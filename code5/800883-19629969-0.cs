    private TimeSpan mPollingInterval;
    private int mMessageGetLimit;
    public override void Run()
    {
        // Refresh the configuration members only when they change.
        RoleEnvironment.Changed += RoleEnvironmentChanged;
        // Initialize them for the first time
        RefreshRoleEnvironmentSettings();
        while (true)
        {
            var messages = queue.GetMessages(mMessageGetLimit);
            if (messages.Count() > 0)
            {
                ProcessQueueMessages(messages);
            }
            else
            {
                Task.Delay(mPollingInterval);
            }
        }
    }
    private void RoleEnvironmentChanged(object sender, RoleEnvironmentChangedEventArgs e)
    {
        RefreshRoleEnvironmentSettings();    
    }
    private void RefreshRoleEnvironmentSettings()
    {
        mPollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(RoleEnvironment.GetConfigurationSettingValue("PollingIntervalSeconds")));
        mMessageGetLimit = Convert.ToInt32(RoleEnvironment.GetConfigurationSettingValue("MessageGetLimit"));
    }
