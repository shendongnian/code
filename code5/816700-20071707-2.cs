    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ServiceStatusChecking
    {
        class QueryServiceStatus
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
            public delegate void StatusChanged(IntPtr parameter);
            public static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    
            /// <summary> 
            /// Block until a service stops or is found to be already dead.
            /// </summary> 
            /// <param name="serviceName">The name of the service you would like to wait for.</param>
            public static void WaitForServiceToStop(string serviceName)
            {
                new Thread(() =>
                {
                    IntPtr hSCM = OpenSCManager(null, null, (uint)0xF003F);
                    if (hSCM != IntPtr.Zero)
                    {
                        IntPtr hService = OpenService(hSCM, serviceName, (uint)0xF003F);
                        if (hService != IntPtr.Zero)
                        {
                            StatusChanged changeDelegate = ReceivedStatusChangedEvent;
                            notify = new SERVICE_NOTIFY();
                            notify.dwVersion = 2;
                            notify.pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(changeDelegate);
                            notifyHandle = GCHandle.Alloc(notify, GCHandleType.Pinned);
                            unmanagedNotifyStructure = notifyHandle.AddrOfPinnedObject();
                            NotifyServiceStatusChange(hService, (uint)0x00000001, unmanagedNotifyStructure);
                            SleepEx(uint.MaxValue, true);
                            notifyHandle.Free();
                        }
                    }
                }).Start();
                autoResetEvent.WaitOne();
            }
    
            public static void ReceivedStatusChangedEvent(IntPtr parameter)
            {
                autoResetEvent.Set();
            }
        }
    }
