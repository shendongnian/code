        // First step: create the trace source object
        TraceSource ts = new TraceSource("myTraceSource");
 
        // Writing out some events
        ts.TraceEvent(TraceEventType.Warning, 0, "warning message");
        ts.TraceEvent(TraceEventType.Error, 0, "error message");
        ts.TraceEvent(TraceEventType.Information, 0, "information message");
        ts.TraceEvent(TraceEventType.Critical, 0, "critical message");
