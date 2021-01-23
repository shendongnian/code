     private void RegisterScheduleIfNotExist(string name, string title, string content, DateTime time)
        {
            ScheduledAction currentReminder = ScheduledActionService.Find(name);
            if (currentReminder != null)
            {
                ScheduledActionService.Remove(currentReminder.Name);
            }
            var reminder = new Reminder(name)
            {
                BeginTime = time,
                Title = title,
                Content = content,
            };
            ScheduledActionService.Add(reminder);
        }
