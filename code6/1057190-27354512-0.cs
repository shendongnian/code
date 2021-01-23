    using System;
    using System.Management;
    namespace PCIeSpeedExample
    {
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_NetworkAdapter");
            foreach (ManagementObject obj in searcher.Get())
            {
                Console.WriteLine("--------------- Adapter ----------------");
                foreach (PropertyData pd in obj.Properties)
                {
                    Console.WriteLine("{0} = {1}", pd.Name, pd.Value);
                }
            }
            Console.Read();
        }
    }
    }
