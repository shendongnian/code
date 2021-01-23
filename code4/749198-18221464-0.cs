        private void LoadEventLogs()
        {
            List<EventRecord> eventLogs = new List<EventRecord>();
            EventLogSession session = new EventLogSession();
            foreach (string logName in session.GetLogNames())
            {
                EventLogQuery query = new EventLogQuery(logName, PathType.LogName);
                query.TolerateQueryErrors = true;
                query.Session = session;
                EventLogWatcher logWatcher = new EventLogWatcher(query);
                logWatcher.EventRecordWritten += 
                       new EventHandler<EventRecordWrittenEventArgs>(LogWatcher_EventRecordWritten);
                try
                {
                    logWatcher.Enabled = true;
                }
                catch (EventLogException) { }
             
                // This is how you'd read the logs
                //using (EventLogReader reader = new EventLogReader(query))
                //{
                //    for (EventRecord eventInstance = reader.ReadEvent(); eventInstance != null; eventInstance = reader.ReadEvent())
                //    {
                //        eventLogs.Add(eventInstance);
                //    }
                //}
            }
        }
