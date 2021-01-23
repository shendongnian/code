    private void RegisterScheduleIfNotExist(int id, string name, string title, string content, DateTime time) 
    {   
        ScheduledAction currentReminder = ScheduledActionService.Find(name);
        if (currentReminder != null)
        {
            ScheduledActionService.Remove(currentReminder.Name);
        }
        var reminder = new Reminder(name)
        {
            Id = id,  //Add the id field here to the reminder
            BeginTime = time,
            Title = title,
            Content = content,
        };
        ScheduledActionService.Add(reminder);
    }
    
