                // Today, 4:00pm
            DateTime now = DateTime.Now;
            DateTime dueTime = new DateTime(now.Year, now.Month, now.Day, 16, 0, 0);
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            for(int i=0;i<30;i++)
            {
                dueTime.AddDays(1);
                XmlDocument toastXml = SetupMyToast(dueTime);
                ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, dueTime);
                toastNotifier.AddToSchedule(scheduledToast);
            }
