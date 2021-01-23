    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows;
    
    namespace WpfApplication3
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                // Get handle to a printer
                var hPrinter = new IntPtr();
                bool open = NativeMethods.OpenPrinterW("Microsoft XPS Document Writer", ref hPrinter, IntPtr.Zero);
                Debug.Assert(open);
    
                /* Query for 99 jobs */
                const uint firstJob = 0u;
                const uint noJobs = 99u;
                const uint level = 1u;
    
                // Get byte size required for the function
                uint needed;
                uint returned;
                bool b1 = NativeMethods.EnumJobsW(
                    hPrinter, firstJob, noJobs, level, IntPtr.Zero, 0, out needed, out returned);
                Debug.Assert(!b1);
                uint lastError = NativeMethods.GetLastError();
                Debug.Assert(lastError == NativeConstants.ERROR_INSUFFICIENT_BUFFER);
    
                // Populate the structs
                IntPtr pJob = Marshal.AllocHGlobal((int) needed);
                uint bytesCopied;
                uint structsCopied;
                bool b2 = NativeMethods.EnumJobsW(
                    hPrinter, firstJob, noJobs, level, pJob, needed, out bytesCopied, out structsCopied);
                Debug.Assert(b2);
    
                var jobInfos = new JOB_INFO_1W[structsCopied];
                int sizeOf = Marshal.SizeOf(typeof (JOB_INFO_1W));
                IntPtr pStruct = pJob;
                for (int i = 0; i < structsCopied; i++)
                {
                    var jobInfo_1W = (JOB_INFO_1W) Marshal.PtrToStructure(pStruct, typeof (JOB_INFO_1W));
                    jobInfos[i] = jobInfo_1W;
                    pStruct += sizeOf;
                }
                Marshal.FreeHGlobal(pJob);
    
                // do something with your structs
            }
        }
    
        public class NativeConstants
        {
            public const int ERROR_INSUFFICIENT_BUFFER = 122;
        }
    
        public partial class NativeMethods
        {
            [DllImport("kernel32.dll", EntryPoint = "GetLastError")]
            public static extern uint GetLastError();
        }
    
        public partial class NativeMethods
        {
            [DllImport("Winspool.drv", EntryPoint = "OpenPrinterW")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool OpenPrinterW([In] [MarshalAs(UnmanagedType.LPWStr)] string pPrinterName,
                ref IntPtr phPrinter, [In] IntPtr pDefault);
    
            [DllImport("Winspool.drv", EntryPoint = "EnumJobsW")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumJobsW([In] IntPtr hPrinter, uint FirstJob, uint NoJobs, uint Level, IntPtr pJob,
                uint cbBuf, [Out] out uint pcbNeeded, [Out] out uint pcReturned);
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct JOB_INFO_1W
        {
            public uint JobId;
            [MarshalAs(UnmanagedType.LPWStr)] public string pPrinterName;
            [MarshalAs(UnmanagedType.LPWStr)] public string pMachineName;
            [MarshalAs(UnmanagedType.LPWStr)] public string pUserName;
            [MarshalAs(UnmanagedType.LPWStr)] public string pDocument;
            [MarshalAs(UnmanagedType.LPWStr)] public string pDatatype;
            [MarshalAs(UnmanagedType.LPWStr)] public string pStatus;
            public uint Status;
            public uint Priority;
            public uint Position;
            public uint TotalPages;
            public uint PagesPrinted;
            public SYSTEMTIME Submitted;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
    }
