    private static void Dependency_OnChanged(object sender, SqlNotificationEventArgs e)
    {
        bool updated  = e.Info == SqlNotificationInfo.Update;
        bool changed  = e.Type == SqlNotificationType.Change;
        bool isClient = e.Source == SqlNotificationSource.Data;
        bool acceptable = updated && changed && isClient;
        if (acceptable)
        {
            MyHub.SendMessages();
        }
    }
