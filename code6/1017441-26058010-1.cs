    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace test1
    {
        class Program
        {        
            static void Main(string[] args)
            {
                var proc = new Process();
                proc.StartInfo = new ProcessStartInfo("rscript")
                {
                    Arguments = "script.R",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
    
                proc.Start();
                proc.StandardInput.WriteLine("Hello");
                var output = proc.StandardOutput.ReadLine();
                Console.WriteLine(output);
            }
        }
    }
