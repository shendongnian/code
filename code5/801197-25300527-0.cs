    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration.Install;
    using System.ServiceProcess;
    using System.ComponentModel;
    
    namespace WindowsService1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    foreach (string item in args)
                    {
                        switch (item.ToLower())
                        {
                            case "-install":
                                Install(false, args); break;
                            case "-uninstall":
                                Install(true, args); break;
                            case "-delevent":
                                DeleteEventStuff(); break;
                            default:
                                Console.Error.WriteLine("Argument not expected: " + item); break;
                        }
                    }
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] 
                    { 
                        new Service1() 
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                
            }
    
            // This is the method that does the actual installing/uninstalling of the service for Windows
            static void Install(bool uninstall, string[] args)
            {
                try
                {
                    Console.WriteLine(uninstall ? "Uninstalling Service" : "Installing Service");
                    using (AssemblyInstaller inst = new AssemblyInstaller(typeof(MyProjectInstaller).Assembly, args))
                    {
                        IDictionary state = new Hashtable();
                        inst.UseNewContext = true;
                        try
                        {
                            if (uninstall)
                            {
                                inst.Uninstall(state);
                                Console.WriteLine();
                                Console.WriteLine("Uninstall Successful");
                            }
                            else
                            {
                                inst.Install(state);
                                Console.WriteLine();
                                Console.WriteLine("Installed Successfuly. Now Commiting...");
                                inst.Commit(state);
                                Console.WriteLine();
                                Console.WriteLine("Commit Successful");
                            }
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                Console.WriteLine();
                                Console.WriteLine("ERROR: " + ex.Message);
                                Console.WriteLine();
                                Console.WriteLine("Rolling back service installation...");
                                inst.Rollback(state);
                                Console.WriteLine();
                                Console.WriteLine("Rollback Successful");
                            }
                            catch { }
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }
    
            // This is the method that cleans up the event logging that Windows creates on install
            static void DeleteEventStuff()
            {
                // Delete the event log stuff that the service actually uses.
                if (System.Diagnostics.EventLog.SourceExists(Service1.eventSource))
                {
                    try
                    {
                        System.Diagnostics.EventLog.DeleteEventSource(Service1.eventSource);
                        Console.WriteLine();
                        Console.WriteLine("Event source deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error deleting event source: " + ex.Message);
                    }
                }
                else
                    Console.WriteLine(); Console.WriteLine("The event source '" + Service1.eventSource + "' does not exist.");
    
                if (System.Diagnostics.EventLog.Exists(Service1.eventLog))
                {
                    try
                    {
                        System.Diagnostics.EventLog.Delete(Service1.eventLog);
                        Console.WriteLine();
                        Console.WriteLine("Event log deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error deleting event log: " + ex.Message);
                    }
                }
                else
                    Console.WriteLine(); Console.WriteLine("The event log '" + Service1.eventLog + "' does not exist.");
    
                // Delete the event log stuff that windows installer utilities thinks the service will use.
                if (System.Diagnostics.EventLog.SourceExists(Service1._serviceName))
                {
                    try
                    {
                        System.Diagnostics.EventLog.DeleteEventSource(Service1._serviceName);
                        Console.WriteLine();
                        Console.WriteLine("Event source deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error deleting event source: " + ex.Message);
                    }
                }
                else
                    Console.WriteLine(); Console.WriteLine("The event source '" + Service1._serviceName + "' does not exist.");
    
                if (System.Diagnostics.EventLog.Exists(Service1._serviceName))
                {
                    try
                    {
                        System.Diagnostics.EventLog.Delete(Service1._serviceName);
                        Console.WriteLine();
                        Console.WriteLine("Event log deleted successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error deleting event log: " + ex.Message);
                    }
                }
                else
                    Console.WriteLine(); Console.WriteLine("The event log '" + Service1._serviceName + "' does not exist.");
    
                // Delete the actual custom event log file stored on the hard drive if it exists so it can be recreated on re-install
                if (System.IO.File.Exists(@"%SystemRoot%\System32\winevt\Logs\" + Service1.eventLog + ".evtx"))
                {
                    try
                    {
                        System.IO.File.Delete(@"%SystemRoot%\System32\winevt\Logs\" + Service1.eventLog + ".evtx");
                        Console.WriteLine();
                        Console.WriteLine("Event log found deleted from hard drive successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error deleting event log from hard drive: " + ex.Message);
                    }
                }
                else
                    Console.WriteLine(); Console.WriteLine("The event log '" + Service1._serviceName + "' file was not found on the hard drive.");
            }
        }
    }
