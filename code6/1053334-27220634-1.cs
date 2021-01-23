        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            try
            {
                // TODO: Insert monitoring activities here.
                eventLog1.WriteEntry("Monitoring the System 1", EventLogEntryType.Information, eventId++);
                using (var db = new LcsCDREntities())
                {
                    eventLog1.WriteEntry("about to query", EventLogEntryType.Information, eventId++);
                    var query = from c in db.ConferenceSessionDetailsViews
                                orderby c.SessionIdSeq
                                select c;
                    eventLog1.WriteEntry("there are " + query.Count().ToString(), EventLogEntryType.Information, eventId++);
                    foreach (var item in query)
                    {
                        eventLog1.WriteEntry("Conference data: " + item.SessionIdTime.ToString(), EventLogEntryType.Information, eventId++);
                    }
                }
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry("Exception: " + ex.Message, EventLogEntryType.Error);
            }
        }
