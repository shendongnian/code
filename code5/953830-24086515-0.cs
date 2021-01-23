        public void GetEvents()
        {
            string FormattedDateTime = string.Format("{0}-{1}-{2}T{3}:{4}:{5}.000000000Z",
                DateTime.Now.Year,
                DateTime.Now.Month.ToString("D2"),
                DateTime.Now.AddDays(-1).Day.ToString("D2"),
                DateTime.Now.Hour.ToString("D2"),
                DateTime.Now.Minute.ToString("D2"),
                DateTime.Now.Second.ToString("D2"));
            string LogSource = @"Application";
            string Query = "*[System[TimeCreated[@SystemTime >= '" + FormattedDateTime + "']]]";
            var QueryResult = new EventLogQuery(LogSource, PathType.LogName, Query);
            var Reader = new System.Diagnostics.Eventing.Reader.EventLogReader(QueryResult);
            List<EventRecord> Events = new List<EventRecord>();
            bool Reading = true;
            while (Reading)
            {
                EventRecord Rec = Reader.ReadEvent();
                if (Rec == null)
                    Reading = false;
                Events.Add(Rec);
                // You could add to your own collection here instead of adding to a list
            }
        }
