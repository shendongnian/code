    using System;
    using System.Runtime.InteropServices;
    
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
                public SERVICE_STATUS_PROCESS ServiceStatus;
                public uint dwNotificationTriggered;
                public IntPtr pszServiceNames;
            };
    
            [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
            public struct SERVICE_STATUS_PROCESS
            {
                public uint dwServiceType;
                public uint dwCurrentState;
                public uint dwControlsAccepted;
                public uint dwWin32ExitCode;
                public uint dwServiceSpecificExitCode;
                public uint dwCheckPoint;
                public uint dwWaitHint;
                public uint dwProcessId;
                public uint dwServiceFlags;
            };
    
            [DllImport("advapi32.dll")]
            static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
    
            [DllImport("advapi32.dll")]
            static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);
    
            [DllImport("advapi32.dll")]
            static extern uint NotifyServiceStatusChange(IntPtr hService, uint dwNotifyMask, IntPtr pNotifyBuffer);
    
            [DllImportAttribute("kernel32.dll")]
            static extern uint SleepEx(uint dwMilliseconds, bool bAlertable);
    
            [DllImport("advapi32.dll")]
            static extern bool CloseServiceHandle(IntPtr hSCObject);
    
            delegate void StatusChangedCallbackDelegate(IntPtr parameter);
    
            /// <summary> 
            /// Block until a service stops or is found to be already dead.
            /// </summary> 
            /// <param name="serviceName">The name of the service you would like to wait for.</param>
            public static void WaitForServiceToStop(string serviceName)
            {
                IntPtr hSCM = OpenSCManager(null, null, (uint)0xF003F);
                if (hSCM != IntPtr.Zero)
                {
                    IntPtr hService = OpenService(hSCM, serviceName, (uint)0xF003F);
                    if (hService != IntPtr.Zero)
                    {
                        StatusChangedCallbackDelegate changeDelegate = ReceivedStatusChangedEvent;
                        SERVICE_NOTIFY notify = new SERVICE_NOTIFY();
                        notify.dwVersion = 2;
                        notify.pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(changeDelegate);
                        notify.ServiceStatus = new SERVICE_STATUS_PROCESS();
                        GCHandle notifyHandle = GCHandle.Alloc(notify, GCHandleType.Pinned);
                        IntPtr unmanagedNotifyStructure = notifyHandle.AddrOfPinnedObject();
                        NotifyServiceStatusChange(hService, (uint)0x00000001, unmanagedNotifyStructure);
                        SleepEx(uint.MaxValue, true);
                        notifyHandle.Free();
                        CloseServiceHandle(hService);
                    }
                    CloseServiceHandle(hSCM);
                }
            }
    
            public static void ReceivedStatusChangedEvent(IntPtr parameter)
            {
    
            }
        }
    }
