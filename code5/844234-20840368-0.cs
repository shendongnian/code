    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Management.Automation;
    using System.Diagnostics;
    namespace PowerShellTest01
    {
        class Program
        {
            static void Main(string[] args)
            {
                // 1. Create PowerShell instance
                var ps = PowerShell.Create();
                // 2. Add C# anonymous method to respond to event
                ps.Streams.Progress.DataAdded += delegate(object sender, DataAddedEventArgs e) { Debug.WriteLine("{0}: Data was added to progress stream", DateTime.Now.ToShortTimeString()); };
                // 3. Add a new ProgressRecord instance
                ps.Streams.Progress.Add(new ProgressRecord(5, "test", "test"));
                // 4. Wait for user input
                Console.Read();
            }
        }
    }
