    public static event EventHandler TestEvent
    {
      add
      {
        lock (lockObj)
        {
          EventHandler oldDel;
          if (EventMapping.TryGetValue(0, out oldDel))
            EventMapping[0] = oldDel + value;
          else
            EventMapping.Add(0, value);
        }
      }
      remove
      {
        lock (lockObj)
        {
          EventHandler oldDel;
          if (EventMapping.TryGetValue(0, out oldDel))
            EventMapping[0] = oldDel - value;
        }
      }
    }
    private static readonly object lockObj = new object();
    private static Dictionary<int, EventHandler> EventMapping = new Dictionary<int, EventHandler>();
