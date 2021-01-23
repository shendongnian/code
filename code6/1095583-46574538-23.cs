    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    class Program
    {
        static void Main(string[] args)
        {
            PrintProcessThreads(Process.GetCurrentProcess().Id);
            PrintProcessThreads(4156); // some other random process on my system
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
        static void PrintProcessThreads(int processId)
        {
            Console.WriteLine(string.Format("Process Id: {0:X4}", processId));
            var threads = Process.GetProcessById(processId).Threads.OfType<ProcessThread>();
            foreach (var pt in threads)
                Console.WriteLine("  Thread Id: {0:X4}, Start Address: {1:X16}",
                                  pt.Id, (ulong) GetThreadStartAddress(pt.Id));
        }
        static IntPtr GetThreadStartAddress(int threadId)
        {
            var hThread = OpenThread(ThreadAccess.QueryInformation, false, threadId);
            if (hThread == IntPtr.Zero)
                throw new Win32Exception();
            var buf = Marshal.AllocHGlobal(IntPtr.Size);
            try
            {
                var result = NtQueryInformationThread(hThread,
                                 ThreadInfoClass.ThreadQuerySetWin32StartAddress,
                                 buf, IntPtr.Size, IntPtr.Zero);
                if (result != 0)
                    throw new Win32Exception(string.Format("NtQueryInformationThread failed; NTSTATUS = {0:X8}", result));
                return Marshal.ReadIntPtr(buf);
            }
            finally
            {
                CloseHandle(hThread);
                Marshal.FreeHGlobal(buf);
            }
        }
        [DllImport("ntdll.dll", SetLastError = true)]
        static extern int NtQueryInformationThread(
            IntPtr threadHandle,
            ThreadInfoClass threadInformationClass,
            IntPtr threadInformation,
            int threadInformationLength,
            IntPtr returnLengthPtr);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, int dwThreadId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);
        [Flags]
        public enum ThreadAccess : int
        {
            Terminate = 0x0001,
            SuspendResume = 0x0002,
            GetContext = 0x0008,
            SetContext = 0x0010,
            SetInformation = 0x0020,
            QueryInformation = 0x0040,
            SetThreadToken = 0x0080,
            Impersonate = 0x0100,
            DirectImpersonation = 0x0200
        }
        public enum ThreadInfoClass : int
        {
            ThreadQuerySetWin32StartAddress = 9
        }
    }
