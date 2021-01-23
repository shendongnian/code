    using System;
    using System.Management;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Searching for driver...");
    
                System.Management.SelectQuery query = new System.Management.SelectQuery("Win32_SystemDriver");
                query.Condition = "Name = 'SomeDriverName'";
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query);
                var drivers = searcher.Get();
    
                if (drivers.Count > 0) Console.WriteLine("Driver exists.");
                else Console.WriteLine("Driver could not be found.");
    
                Console.ReadLine();
            }
        }
    }
