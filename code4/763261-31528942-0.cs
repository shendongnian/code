    string query = "*[System[(EventRecordID=" + entry.Entry.Index + ")]]";
    // Create Event Log Query and Reader
    EventLogQuery eventsQuery = new EventLogQuery("Security",
                                              PathType.LogName,
                                              query);
    EventLogReader logReader = new EventLogReader(eventsQuery);
    EventRecord eventInstance = logReader.ReadEvent();
    if (eventInstance != null)
    {
        XDocument xml;
        try
        {
            xml = XDocument.Parse(eventInstance.ToXml());
        }
        catch (Exception e)
        {
            //This probably won't happen now.
            break;      //We seem to have a newline character in the 
        }
    }
