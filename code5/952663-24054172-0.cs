    Reminder reminder = new Reminder(name);
    reminder.Title = titleTextBox.Text;
    reminder.Content = contentTextBox.Text;
    reminder.BeginTime = beginTime; // it is the time when remider will start reminding(e.g remind me after 8 days and 2 AM hours you will set it DateTime.Now.Date.AddDays(8).AddHours(2)
    reminder.ExpirationTime = expirationTime;
    reminder.RecurrenceType = recurrence;
    reminder.NavigationUri = navigationUri;
    // Register the reminder with the system.
    ScheduledActionService.Add(reminder);
