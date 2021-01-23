    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
            public class SERVICE_NOTIFY
            {
                public uint dwVersion;
                public IntPtr pfnNotifyCallback;
                public IntPtr pContext;
                public uint dwNotificationStatus;
                public IntPtr ServiceStatus;
                public uint dwNotificationTriggered;
                public IntPtr pszServiceNames;
            };
    
            [DllImport("advapi32.dll", SetLastError = true)]
            static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern uint NotifyServiceStatusChange(IntPtr hService, uint dwNotifyMask, IntPtr pNotifyBuffer);
    
            [DllImportAttribute("kernel32.dll", EntryPoint = "SleepEx")]
            public static extern uint SleepEx(uint dwMilliseconds, bool bAlertable);
    
            public static SERVICE_NOTIFY notify;
            public static GCHandle notifyHandle;
            public static IntPtr unmanagedNotifyStructure;
    
            static void Main(string[] args)
            {
                IntPtr hSCM = OpenSCManager(null, null, (uint)0xF003F);
                if (hSCM != IntPtr.Zero)
                {
                    IntPtr hService = OpenService(hSCM, "ice Log Service", (uint)0xF003F);
                    if (hService != IntPtr.Zero)
                    {
                        StatusChanged changeDelegate = ReceivedStatusChangedEvent;
                        notify = new SERVICE_NOTIFY();
                        notify.dwVersion = 2;
                        notify.pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(changeDelegate);
                        notify.pContext = IntPtr.Zero;
                        notify.dwNotificationStatus = 0;
                        notify.ServiceStatus = IntPtr.Zero;
                        notify.dwNotificationTriggered = 0;
                        notify.pszServiceNames = IntPtr.Zero;
                        notifyHandle = GCHandle.Alloc(notify, GCHandleType.Pinned);
                        unmanagedNotifyStructure = notifyHandle.AddrOfPinnedObject();
                        NotifyServiceStatusChange(hService, (uint)0x00000001, unmanagedNotifyStructure);
                        Console.WriteLine("Waiting for the service to stop.");
                        SleepEx(uint.MaxValue, true);
                        Console.WriteLine("The main thread has been alerted.");
                        Console.ReadLine();
                    }
                }
            }
    
            public delegate void StatusChanged(IntPtr parameter);
            public static void ReceivedStatusChangedEvent(IntPtr parameter)
            {
                Console.WriteLine("The service has stopped, or is already stopped.");
            }
    
        }
    }
