    using System;
    using System.Management.Automation;
    namespace PowerShellTest02
    {
        class Program
        {
            static void Main(string[] args)
            {
                string func = @"function Test { Write-Host 'hello' };";
                PowerShell ps = PowerShell.Create();
                ps.AddScript(func);
                ps.Invoke();
                ps.AddCommand("Test");
                ps.Invoke();
                Console.WriteLine("Successfully executed function");
                Console.ReadLine();
            }
        }
    }
