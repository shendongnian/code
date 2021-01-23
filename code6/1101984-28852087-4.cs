    class MyTraceListener : TraceListener
    {
      public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
      {
        base.TraceData(eventCache, source, eventType, id, data);
        // do what you want with the objects in the "data" parameter
      }
    }
