    string query = "*[System/EventID=17137 ]";
    EventLogQuery eventsQuery = new EventLogQuery("Application", PathType.LogName, query);
     
    try
        {
        EventLogReader logReader = new EventLogReader(eventsQuery);
     
        for (EventRecord eventdetail = logReader.ReadEvent(); eventdetail != null; eventdetail = logReader.ReadEvent())
        {
            // Read Event details
        }
    }
    catch (EventLogNotFoundException e)
    {
        Console.WriteLine("Error while reading the event logs");
        return;
    }
