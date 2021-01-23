      static void Main(string[] args)
      {
         Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
         Trace.WriteLine("my output string");
         Console.Write("Press enter to quit");
         Console.ReadLine();
      }
