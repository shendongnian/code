    public void dependency_OnChange(object sender, SqlNotificationEventArgs e)
            {
                if (e.Type == SqlNotificationType.Change)
                {
                    NotificationHub.Show();
                }
                GetData();
            }
