    int x = int.Parse(NewEventYear.SelectedItem.ToString());          
    int y = int.Parse(NewEventMonth.SelectedItem.ToString());
    int z = int.Parse(NewEventDate.SelectedItem.ToString());
    int a = int.Parse(NewEventHour.SelectedItem.ToString());
    int b = int.Parse(NewEventMinutes.SelectedItem.ToString()); 
    DateTime EventDate = new DateTime(x,y,z,a,b,0)
    TimeSpan NotTime = EventDate.Subtract(DateTime.Now);
    DateTime dueTime = DateTime.Now.Add(NotTime);
    
    ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toastXml, dueTime);
    ToastNotificationManager.CreateToastNotifier().AddToSchedule(scheduledToast);
