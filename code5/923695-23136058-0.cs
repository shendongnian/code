    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Management.Automation;
    
    namespace PowerShellFormatTableTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ps = PowerShell.Create()
                    .AddCommand("Get-Process")
                    .AddCommand("Format-Table")
                    .AddCommand("Out-String");
    
                Console.WriteLine(ps.Invoke()[0]);
            }
        }
    }
