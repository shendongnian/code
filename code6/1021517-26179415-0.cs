            EventLog appLogs = new EventLog();
            appLogs.Log = "Application";
            DateTime timeToWrite = DateTime.Now;
            foreach (EventLogEntry entry in appLogs.Entries)
            {
                if (entry.TimeWritten == timeToWrite)
                    Console.WriteLine("\tEntry: " + entry.Message);
            }
