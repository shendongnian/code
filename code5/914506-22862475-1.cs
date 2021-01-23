    TextWriterTraceListener[] listeners = new TextWriterTraceListener[] 
    {
          new TextWriterTraceListener("C:\\debugROAR.txt")
          //new TextWriterTraceListener(Console.Out)
    };
    Debug.Listeners.Clear(); // Remove the default listener
    Debug.Listeners.AddRange(listeners);
    
    Debug.WriteLine("Some Value", "Some Category");
    Debug.WriteLine("Some Other Value");
    Debug.AutoFlush = true;
