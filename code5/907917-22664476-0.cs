    private List<ScheduledAction> getStorage()
    {
        if (!userSettings.Contains("notifications"))
        {
            userSettings.Add("notifications", new List<ScheduledAction>());
           userSettings.Save();
        }
    
        return (List<ScheduledAction>)userSettings["notifications"];
    }
    private void saveStorage(List<ScheduledAction> list)
    {
        userSettings["notifications"] = list;
        userSettings.Save();
    }
