    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "test.bat";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();
                string output = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(output); // or do something else with the output
                proc.WaitForExit();
                Console.ReadKey();
            }
        }
    }
