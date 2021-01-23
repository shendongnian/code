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
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
    
            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern uint NotifyServiceStatusChange(IntPtr hService, uint dwNotifyMask, IntPtr pNotifyBuffer);
    
            [DllImportAttribute("kernel32.dll", EntryPoint = "SleepEx")]
            public static extern uint SleepEx(uint dwMilliseconds, [MarshalAsAttribute(UnmanagedType.Bool)] bool bAlertable);
    
            public static SERVICE_NOTIFY notify;
            public static GCHandle notifyHandle;
            public static IntPtr unmanagedNotifyStructure;
    
            static void Main(string[] args)
            {
                IntPtr hSCM = OpenSCManager(null, null, (uint)0xF003F);
                if (hSCM != IntPtr.Zero)
                {
                    IntPtr hService = OpenService(hSCM, "Apache2.2", (uint)0xF003F);
                    if (hService != IntPtr.Zero)
                    { 
                        StatusChanged changeDelegate = ReceivedStatusChangedEvent;
                        
    
                        notify = new SERVICE_NOTIFY();
                        notify.dwVersion = 2;
                        notify.pfnNotifyCallback = Marshal.GetFunctionPointerForDelegate(changeDelegate);
                        notify.pContext = IntPtr.Zero;
                        notify.dwNotificationStatus = 0;
                        SERVICE_STATUS_PROCESS process;
                        process.dwServiceType = 0;
                        process.dwCurrentState = 0;
                        process.dwControlsAccepted = 0;
                        process.dwWin32ExitCode = 0;
                        process.dwServiceSpecificExitCode = 0;
                        process.dwCheckPoint = 0;
                        process.dwWaitHint = 0;
                        process.dwProcessId = 0;
                        process.dwServiceFlags = 0;
                        notify.ServiceStatus = process;
                        notify.dwNotificationTriggered = 0;
                        notify.pszServiceNames = Marshal.StringToHGlobalUni("Apache2.2");
                        notifyHandle = GCHandle.Alloc(notify, GCHandleType.Pinned);
                        unmanagedNotifyStructure = notifyHandle.AddrOfPinnedObject();
                        NotifyServiceStatusChange(hService, (uint)0x00000001, unmanagedNotifyStructure);
                        
                        GC.KeepAlive(changeDelegate);
    
                        Console.WriteLine("Waiting for the service to stop. Press enter to exit.");
                        while (true)
                        {
                            try
                            {
                                string keyIn = Reader.ReadLine(500);
                                break;
                            }
                            catch (TimeoutException)
                            {
                                SleepEx(100,true);
                            }
                        }
                        notifyHandle.Free();
                    }
                }
            }
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            public delegate void StatusChanged(IntPtr parameter);
            public static void ReceivedStatusChangedEvent(IntPtr parameter)
            {
                Console.WriteLine("Service stopped.");
            }
    
        }
    }
    
    class Reader
    {
        private static Thread inputThread;
        private static AutoResetEvent getInput, gotInput;
        private static string input;
    
        static Reader()
        {
            inputThread = new Thread(reader);
            inputThread.IsBackground = true;
            inputThread.Start();
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
        }
    
        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                input = Console.ReadLine();
                gotInput.Set();
            }
        }
    
        public static string ReadLine(int timeOutMillisecs)
        {
            getInput.Set();
            bool success = gotInput.WaitOne(timeOutMillisecs);
            if (success)
                return input;
            else
                throw new TimeoutException("User did not provide input within the timelimit.");
        }
    }
