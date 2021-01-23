    private static void Dependency_OnChanged(object sender, SqlNotificationEventArgs e)
    {
        SqlDependency dependency = sender as SqlDependency;
        try
        {
            dependency.OnChange -= Dependency_OnChanged;
            bool updated  = e.Info == SqlNotificationInfo.Update;
            bool changed  = e.Type == SqlNotificationType.Change;
            bool isClient = e.Source == SqlNotificationSource.Data;
            bool acceptable = updated && changed && isClient;
            if (acceptable)
            {
                MyHub.SendMessages();
            }
        }
        catch(Exception ex) //...
        {
            //handle exception here ...
        }
        finally
        {
            dependency.OnChange += Dependency_OnChanged;
        }
    }
