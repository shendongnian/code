    Trace.Listeners.Clear();
    Trace.Listeners.Add(new ConsoleTraceListener());
    Trace.Listeners.Add(new TextWriterTraceListener("Test.txt"));
    Trace.AutoFlush = true;
    for (int i = 0; i < N; i++)    
         Trace.WriteLine(position[i] + " ");
          
