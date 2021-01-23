    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace EventWatcher
    {
        class Program
        {
            static void Main(string[] args)
            {
                StartMonitoringProcessCreation();
                StartMonitoringProcessTermination();
                Console.ReadLine();
            }
    
            private static void StartMonitoringProcessCreation()
            {
                ManagementEventWatcher startWatcher = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
                startWatcher.EventArrived += new EventArrivedEventHandler(startWatcher_EventArrived);
                startWatcher.Stopped += new StoppedEventHandler(startWatcher_Stopped);
                startWatcher.Disposed += new EventHandler(startWatcher_Disposed);
                startWatcher.Start();
            }
    
            private static void StartMonitoringProcessTermination()
            {
                ManagementEventWatcher stopWatcher = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStopTrace");
                stopWatcher.EventArrived += new EventArrivedEventHandler(stopWatcher_EventArrived);
                stopWatcher.Stopped += new StoppedEventHandler(stopWatcher_Stopped);
                stopWatcher.Disposed += new EventHandler(stopWatcher_Disposed);
                stopWatcher.Start();
            }
    
            static void startWatcher_EventArrived(object sender, EventArrivedEventArgs e)
            {
                Console.WriteLine("Got creation event.");
            }
    
            static void startWatcher_Stopped(object sender, StoppedEventArgs e)
            {
                Console.WriteLine("The startWatcher has stopped. Disposing it.");
                ((ManagementEventWatcher)sender).Dispose();
            }
    
            static void startWatcher_Disposed(object sender, EventArgs e)
            {
                Console.WriteLine("The startWatcher has been disposed. Restarting it.");
                StartMonitoringProcessCreation();
            }
    
            static void stopWatcher_EventArrived(object sender, EventArrivedEventArgs e)
            {
                Console.WriteLine("Got termination event.");
            }
    
            static void stopWatcher_Stopped(object sender, StoppedEventArgs e)
            {
                Console.WriteLine("The stopWatcher has stopped. Disposing it.");
                ((ManagementEventWatcher)sender).Dispose();
            }
    
            static void stopWatcher_Disposed(object sender, EventArgs e)
            {
                Console.WriteLine("The stopWatcher has been disposed. Restarting it.");
                StartMonitoringProcessTermination();
            }
        }
    }
