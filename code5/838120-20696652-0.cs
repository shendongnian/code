    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace GetWMI_Info
    {
        class Program
        {
    	
            static void Main(string[] args)
            {
                try
                {
                    ManagementScope Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "localhost"), null);
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_CDROMDrive");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        String InterfaceType =  ((String)WmiObject["DeviceID"]).Substring(0, ((String)WmiObject["DeviceID"]).IndexOf(@"\"));
                        Console.WriteLine("{0,-35} {1,-40}", "InterfaceType", InterfaceType);
                        Console.WriteLine("{0,-35} {1,-40}","Drive",WmiObject["Drive"]);
                        Console.WriteLine("{0,-35} {1,-40}","Name",WmiObject["Name"]);
    	                    
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(String.Format("Exception {0} Trace {1}",e.Message,e.StackTrace));
                }
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
        }
    }
