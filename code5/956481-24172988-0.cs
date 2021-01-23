    for (int j = 0; j < this.listeners.Count; j++)
    {
        TraceListener listener = this.listeners[j];
        listener.TraceEvent(eventCache, this.Name, eventType, id, format, args);
        if (Trace.AutoFlush)
        {
            listener.Flush();
        }
    }
