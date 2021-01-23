    private void OnChange(object sender, SqlNotificationEventArgs e) {
        ((SqlDependency)sender).OnChange -= OnChange;
        if (e.Source == SqlNotificationSource.Timeout) {
            // just restart notification
        }
        else if (e.Source != SqlNotificationSource.Data) {
            Logger.Error("Unhandled change notification {0}/{1} ({2})", e.Type, e.Info, e.Source);
            ServiceRunner.ShutDown(true);
        }
        else if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Insert) {
            _changeWorkerNotifier.Set(); // AutoResetEvent
        }
        else {
            Logger.Log("Ignored change notification {0}/{1} ({2})", e.Type, e.Info, e.Source);
        }
        CreateDependency();
    }
