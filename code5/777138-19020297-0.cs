        private void StartAgentTask()
        {
            var LiveTilesName = "LiveTiles";
            var ToastNotificationsName = "ToastNotifications";
            PeriodicTask LiveTilesPeriodicTask = ScheduledActionService.Find(LiveTilesName) as PeriodicTask;
            ResourceIntensiveTask ToastNotificationResourceIntensiveTask = ScheduledActionService.Find(ToastNotificationsName) as ResourceIntensiveTask;
            if (LiveTilesPeriodicTask != null)
                ScheduledActionService.Remove(LiveTilesName);
            if (ToastNotificationResourceIntensiveTask != null)
                ScheduledActionService.Remove(ToastNotificationsName);
            LiveTilesPeriodicTask = new PeriodicTask(LiveTilesName) { Description = "Update Live Tiles." };
            ToastNotificationResourceIntensiveTask = new ResourceIntensiveTask(ToastNotificationsName) { Description = "Toast Notifications" };
            try
            {
                ScheduledActionService.Add(LiveTilesPeriodicTask);
                ScheduledActionService.LaunchForTest(LiveTilesName, TimeSpan.FromSeconds(10));
                ScheduledActionService.Add(ToastNotificationResourceIntensiveTask);
                
                double seconds;
                if (DateTime.Now.TimeOfDay <= new TimeSpan(8, 30, 00))
                {
                    seconds = 30600 - DateTime.Now.TimeOfDay.TotalSeconds;
                    //seconds = 38100 - DateTime.Now.TimeOfDay.TotalSeconds;
                }
                else
                {
                    seconds = 117000 - DateTime.Now.TimeOfDay.TotalSeconds;
                    //seconds = 124500 - DateTime.Now.TimeOfDay.TotalSeconds;
                }
                
                ScheduledActionService.LaunchForTest(ToastNotificationsName, TimeSpan.FromSeconds(seconds));
            }
            catch (InvalidOperationException e) { }
            
        }
