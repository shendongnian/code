        protected override void OnInvoke(ScheduledTask Task)
        {
            //ScheduledActionService.LaunchForTest("ToastNotifications", TimeSpan.FromSeconds(30));
            if (Task.Name == "ToastNotifications")
            {                             
                SendNotifications(); // To Call the SendNotification method and It'l be send the notification to the user at the specified time when the application is not running
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
                ScheduledActionService.LaunchForTest(Task.Name, TimeSpan.FromSeconds(seconds));              
            }
            else if(Task.Name == "LiveTiles")
            {
                UpdateTiles(); // To Cal the UpdateTiles method and  It'l update the current tile.               
                ScheduledActionService.LaunchForTest(Task.Name, TimeSpan.FromSeconds(30));
            }
            else{}
            NotifyComplete();
        }
