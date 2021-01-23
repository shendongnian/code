        private DateTimeOffset? mostRecentCallback = null;
        private void CallbackMonitor()
        {
            var midnight = new DateTimeOffset(DateTimeOffset.Now.Year, 
                                              DateTimeOffset.Now.Month, 
                                              DateTimeOffset.Now.Day, 
                                              0,              // Hour 
                                              0,              // Minute 
                                              0,              // Second 
                                              DateTimeOffset.Now.Offset);
            if (!mostRecentCallback.HasValue 
                || mostRecentCallback.Value < midnight)
            {
                mostRecentCallback = midnight;
                // Perform your report generation & send email-related tasks
                // ...do your work here...
                
                // Schedule subsequent callback
                ScheduleMidnightCallback();
            }
        }
