                    Uri navigationUri = new Uri("/ShowDetails.xaml", UriKind.Relative);
                    Reminder reminder = new Reminder(name);
                    reminder.Title = titleTextBox.Text;
                    reminder.Content = contentTextBox.Text;
                    reminder.BeginTime = beginTime;
                    reminder.ExpirationTime = expirationTime;
                    reminder.RecurrenceType = recurrence;
                    reminder.NavigationUri = navigationUri;
    
                  //   Register the reminder with the system.
                    ScheduledActionService.Add(reminder);
