    using System;
    using System.Management;
    
    namespace WMI_example_01
    {
        class Program
        {
            static void Main(string[] args)
            {
                var scope = new ManagementScope(@"\\.\root\cimv2");
                var query = new ObjectQuery("SELECT * FROM win32_tcpipprinterport");
                var searcher = new ManagementObjectSearcher(scope, query);
                var collection = searcher.Get();
    
                foreach(var col in collection)
                {
                    Console.WriteLine("Port name: {0}\tHostAddress: {1}", col["Name"], col"HostAddress"]);
                }
            }
        }
    }
