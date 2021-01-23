        private void RegisterReminder()
        {
            var reminder = ScheduledActionService.Find(ename) as Reminder ?? new Reminder(ename);
            reminder.Title = ename;
            reminder.Content = desc;
    // parse eventDate,utimee to beginDateTime
            reminder.BeginTime = beginDateTime;
            reminder.ExpirationTime = reminder.BeginTime.AddDays(1);
            reminder.RecurrenceType = RecurrenceInterval.None;
            if (ScheduledActionService.Find(ename) == null)
               ScheduledActionService.Add(reminder);
            else
               ScheduledActionService.Replace(reminder);
           MessageBox.Show("reminder set succeed!");
        } 
