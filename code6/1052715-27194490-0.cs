    using (ConsoleTraceListener listener = new ConsoleTraceListener()) {
      Trace.Listeners.Add(listener);
    
      Debug.WriteLine("test");
    
    }
