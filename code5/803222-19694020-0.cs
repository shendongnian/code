    public static EventRecord GetEventRecord(string eventFile, int eventID)
    {
      string sQuery = string.Format("*[System/EventID={0}]", eventID);
      EventLogQuery query = new EventLogQuery(eventFile, PathType.FilePath, sQuery);
      EventLogReader reader = new EventLogReader(query);
      return reader.ReadEvent();
    }
