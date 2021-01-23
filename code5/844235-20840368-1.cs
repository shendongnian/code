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
                ps.Streams.Progress.DataAdded += delegate(object sender, DataAddedEventArgs e) { Debug.WriteLine("Data was added to progress stream"); };
                // 3. Add a new ProgressRecord instance
                ps.Streams.Progress.Add(new ProgressRecord(5, "test", "test"));
                // 4. Add a PowerShell script that calls Write-Progress
                ps.AddScript("1..5 | % { Write-Progress -Activity 'My Important Activity' -PercentComplete ($PSItem*20) -Status 'This is my status'; Start-Sleep -Milliseconds 200; }");
                // 5. Invoke the script synchronously
                ps.Invoke();
                // 6. Wait for user input
                Console.Read();
            }
        }
    }
