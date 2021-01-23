    using System;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace ServiceAssistant
    {
        class ServiceHelper
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
            /// Block until a service stops, is killed, or is found to be already dead.
            /// </summary> 
            /// <param name="serviceName">The name of the service you would like to wait for.</param>
            /// <param name="timeout">An amount of time you would like to wait for. uint.MaxValue is the default, and it will force this thread to wait indefinitely.</param>
            public static void WaitForServiceToStop(string serviceName, uint timeout = uint.MaxValue)
            {
                // Ensure that this thread's identity is mapped, 1-to-1, with a native OS thread.
                Thread.BeginThreadAffinity();
                GCHandle notifyHandle = default(GCHandle);
                StatusChangedCallbackDelegate changeDelegate = ReceivedStatusChangedEvent;
                IntPtr hSCM = IntPtr.Zero;
                IntPtr hService = IntPtr.Zero;
                try
                {
                    hSCM = OpenSCManager(null, null, (uint)0xF003F);
                    if (hSCM != IntPtr.Zero)
                    {
                        hService = OpenService(hSCM, serviceName, (uint)0xF003F);
                        if (hService != IntPtr.Zero)
                        {
                            SERVICE_NOTIFY notify = new SERVICE_NOTIFY();
                            notify.dwVersion = 2;
                            notify.pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(changeDelegate);
                            notify.ServiceStatus = new SERVICE_STATUS_PROCESS();
                            notifyHandle = GCHandle.Alloc(notify, GCHandleType.Pinned);
                            IntPtr pinnedNotifyStructure = notifyHandle.AddrOfPinnedObject();
                            NotifyServiceStatusChange(hService, (uint)0x00000001, pinnedNotifyStructure);
                            SleepEx(timeout, true);
                        }
                    }
                }
                finally
                {
                    // Clean up at the end of our operation, or if this thread is aborted.
                    if (hService != IntPtr.Zero)
                    {
                        CloseServiceHandle(hService);
                    }
                    if (hSCM != IntPtr.Zero)
                    {
                        CloseServiceHandle(hSCM);
                    }
                    GC.KeepAlive(changeDelegate);
                    if (notifyHandle != default(GCHandle))
                    {
                        notifyHandle.Free();
                    }
                    Thread.EndThreadAffinity();
                }
            }
    
            public static void ReceivedStatusChangedEvent(IntPtr parameter)
            {
    
            }
        }
    }
