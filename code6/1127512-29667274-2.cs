    private static List<IEventCaller> eventCallers = new List<IEventCaller>();
   
    public static void AddEventCaller(IEventCaller c)
    {
        eventCallers.Add(c);
    }
    public static void RemoveEventCaller(IEventCaller c)
    {
        eventCallers.Remove(c);
    }
    public static IEventCaller[] EventCallers
    {
        get { return eventCallers.ToArray() }
    }
