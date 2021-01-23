    TextWriterTraceListener[] listeners = new TextWriterTraceListener[] {
                new TextWriterTraceListener("W:\\C.txt"),
              new TextWriterTraceListener(Console.Out)};
    Debug.Listeners.AddRange(listeners);
    Debug.WriteLine("Some Value", "Some Category");
    Debug.Flush()
