        static void Main(string[] args)
        {
            EventLog el = new EventLog("Application", "MY-PC");
            foreach (EventLogEntry entry in el.Entries)
            {
                if (entry.EntryType == EventLogEntryType.Error)
                {
                    Console.WriteLine(entry.Message);
                }
            }
        }
