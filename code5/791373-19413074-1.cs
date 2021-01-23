        AssertTextWriterTraceListener fileTL = new AssertTextWriterTraceListener(debugFile);
        AssertTextWriterTraceListener consoleTL = new AssertTextWriterTraceListener(Console.Out);
        System.Diagnostics.Trace.AutoFlush = true; // necessary to get the Debug-Messages flushed to the debugFile
        // clearing the default listener and adding the custom ones.
        Debug.Listeners.Clear();
        Debug.Listeners.Add(fileTL);
        Debug.Listeners.Add(consoleTL);
