    using System.Diagnostics;
    using System.IO;
    
    namespace TrackingExecutionPath
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var myFile = File.Create(@"C:\Application.log");
                Trace.Listeners.Add(new TextWriterTraceListener(myFile));
    
                Trace.WriteLine("Starting up");
                var tracer = new Tracer();
                tracer.TraceMeOnce();
                Trace.WriteLine("Wrapping up");
    
                Trace.Flush();
            }
    
        }
    
        internal class Tracer
        {
            public void TraceMeAgain()
            {
                Trace.IndentLevel++;
                Trace.WriteLine("Entering TraceMeAgain");
                Trace.WriteLine("Doing some work.");
                Trace.WriteLine("Exiting TraceMeAgain");
                Trace.IndentLevel--;
            }
    
            public void TraceMeOnce()
            {
                Trace.IndentLevel++;
                Trace.WriteLine("Entering TraceMeOnce");
                Trace.WriteLine("Doing some work.");
                TraceMeAgain();
                Trace.WriteLine("Exiting TraceMeOnce");
                Trace.IndentLevel--;
            }
        }
    }
