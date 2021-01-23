        static void Main(string[] args)
        {
            Process p = Process.GetCurrentProcess();
            ParentProcessUtilities pInfo = new ParentProcessUtilities();
            int l;
            int error = NtQueryInformationProcess(p.Handle, 0, ref pInfo, Marshal.SizeOf(typeof(ParentProcessUtilities)), out l);
            if (error == 0)
            {
                var parent = Process.GetProcessById(pInfo.InheritedFromUniqueProcessId.ToInt32());
                Console.WriteLine("My parent is: {0}", parent.ProcessName);
            }
            else
            {
                Console.WriteLine("Error occured: {0:X}", error);
            }
            Console.ReadKey();
        }
        [DllImport("ntdll.dll")]
        private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct ParentProcessUtilities
    {
        // These members must match PROCESS_BASIC_INFORMATION
        internal IntPtr Reserved1;
        internal IntPtr PebBaseAddress;
        internal IntPtr Reserved2_0;
        internal IntPtr Reserved2_1;
        internal IntPtr UniqueProcessId;
        internal IntPtr InheritedFromUniqueProcessId;
    }
