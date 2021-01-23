        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency dependency = sender as SqlDependency;
            if (dependency != null) dependency.OnChange -= dependency_OnChange;
            if (e.Type == SqlNotificationType.Change)
            {
                // Do things
            }
            SetupDatabaseDependency();
        }
