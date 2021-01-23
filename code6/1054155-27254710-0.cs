    public IEnumerable<EventRecord> QueryEventRecords(string queryString)
    {
        var query = new EventLogQuery("Application", PathType.LogName, queryString);
        using (var reader = new EventLogReader(query))
        {
            EventRecord eventRecord;
            while ((eventRecord = reader.ReadEvent()) != null)
            {
                yield return eventRecord;
            }
        }
    }
