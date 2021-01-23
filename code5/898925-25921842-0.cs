    using System;
    using WMemoryProfiler;
    
    namespace AllocateManyObjects
    {
        /// <summary>
        /// Shows the basic usage of WMemoryProfiler
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // Start this application not under the debugger
                    // To start is press Ctrl+F5 in Visual Studio to start it without debugging.
    
                    SelfDebug();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Got Exception: {0}", ex);
                }
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
    
    
            /// <summary>
            /// Issue a !Threads command and print the output to console
            /// </summary>
            private static void SelfDebug()
            {
                using (var debugger = new MdbEng())
                {
                    string[] output = debugger.Execute("!FinalizeQueue");
                    Console.WriteLine(String.Join(Environment.NewLine, output));
                }
            }
        }
    }
