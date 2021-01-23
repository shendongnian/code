    using System;
    using System.Management;
    
    namespace ProcessListener
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementEventWatcher psStartEvt = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
                ManagementEventWatcher psStopEvt = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
    
                psStartEvt.EventArrived += (s, e) =>
                    {
                        string name = e.NewEvent.Properties["ProcessName"].Value.ToString();
                        string id = e.NewEvent.Properties["ProcessID"].Value.ToString();
                        Console.WriteLine("Started: {0} ({1})", name, id);
                    };
    
                psStopEvt.EventArrived += (s, e) =>
                    {
                        string name = e.NewEvent.Properties["ProcessName"].Value.ToString();
                        string id = e.NewEvent.Properties["ProcessID"].Value.ToString();
                        Console.WriteLine("Stopped: {0} ({1})", name, id);
                    };
    
                psStartEvt.Start();
                psStopEvt.Start();
                Console.ReadLine();
            }
        }
    }
