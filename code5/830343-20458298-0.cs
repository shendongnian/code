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
                    ManagementScope Scope;
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "localhost"), null);
    
                    Scope.Connect();
                    ObjectQuery Query = new ObjectQuery("SELECT * FROM Win32_LoggedOnUser");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
    
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        //Console.WriteLine("{0,-35} {1,-40}","Antecedent",WmiObject["Antecedent"]);// Reference
                        //Console.WriteLine("{0,-35} {1,-40}","Dependent",WmiObject["Dependent"]);// Reference
                        ManagementObject oAntecedent = new ManagementObject();
                        ManagementPath ObjectPath = new ManagementPath((String)WmiObject["Antecedent"]);//Win32_Account 
                        oAntecedent.Path = ObjectPath;
                        oAntecedent.Get();
                       
                        Console.WriteLine("{0,-35} {1,-40}", "Caption", oAntecedent["Caption"]);// String
                        Console.WriteLine("{0,-35} {1,-40}", "Description", oAntecedent["Description"]);// String
                        Console.WriteLine("{0,-35} {1,-40}", "Domain", oAntecedent["Domain"]);// String
                        //Console.WriteLine("{0,-35} {1,-40}", "InstallDate", ManagementDateTimeConverter.ToDateTime((string)WmiObject["InstallDate"]));// Datetime
                        Console.WriteLine("{0,-35} {1,-40}", "LocalAccount", oAntecedent["LocalAccount"]);// Boolean
                        Console.WriteLine("{0,-35} {1,-40}", "Name", oAntecedent["Name"]);// String
                        Console.WriteLine("{0,-35} {1,-40}", "SID", oAntecedent["SID"]);// String
                        Console.WriteLine("{0,-35} {1,-40}", "SIDType", oAntecedent["SIDType"]);// Uint8
                        Console.WriteLine("{0,-35} {1,-40}", "Status", oAntecedent["Status"]);// String
                        Console.WriteLine();    
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
