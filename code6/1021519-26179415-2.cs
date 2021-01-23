            EventLog appLogs = new EventLog();
            appLogs.Log = "Application";
            DateTime timeToWrite = DateTime.Now;
            var entriesToWrite = appLogs.Entries.Cast<EventLogEntry>().Where(x => x.TimeWritten == timeToWrite);
            foreach (EventLogEntry entry in entriesToWrite)
            {
                if (entry.TimeWritten == timeToWrite)
                    Console.WriteLine("\tEntry: " + entry.Message);
            }
