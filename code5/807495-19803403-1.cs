    using System;
    using System.Diagnostics;
    
    namespace EventLogTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var log = new EventLog("LogA");
    
                Console.WriteLine(log.Entries.Count);
            }
        }
    }
