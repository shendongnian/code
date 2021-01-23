    var reminder = ScheduledActionService.Find(id) as Reminder ?? new Reminder(id);
    reminder.Title = "...";
    reminder.Content = "...";
    reminder.BeginTime = yourDate;
    reminder.ExpirationTime = yourDate;
    reminder.RecurrenceType = oneType;
    reminder.RecurrenceType = RecurrenceInterval.None;
    if (ScheduledActionService.Find(id) == null)
       ScheduledActionService.Add(reminder);
    else
    ScheduledActionService.Replace(reminder);
