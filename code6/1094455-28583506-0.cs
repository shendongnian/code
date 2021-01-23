    public NotificationsResult Get(string machineName)
    {
        int NotificationsNumber = NotificationsFunctions.CheckForNotifications(machineName);
        return new NotificationsResult
        {
            Result = NotificationsNumber > 0 ? "true" : "false";             
        };
    }
