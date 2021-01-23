    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    namespace FunctionTiming
    {
        class Program
        {
            private static Thread _thread;
            private static IntPtr _threadHandle;
            static void Main(string[] args)
            {
                _thread = new Thread(new ThreadStart(Program.TargetFunction));
                _thread.Start();
                _thread.Join();
                System.Runtime.InteropServices.ComTypes.FILETIME start, end, rawKernelTime, rawUserTime;
                bool result = GetThreadTimes(_threadHandle, out start, out end, out rawKernelTime, out rawUserTime);
                Debug.Assert(result);
                ulong uLow = (ulong)rawKernelTime.dwLowDateTime;
                ulong uHigh = (uint)rawKernelTime.dwHighDateTime;
                uHigh = uHigh << 32;
                long kernelTime = (long)(uHigh | uLow);
                uLow = (ulong)rawUserTime.dwLowDateTime;
                uHigh = (uint)rawUserTime.dwHighDateTime;
                uHigh = uHigh << 32;
                long userTime = (long)(uHigh | uLow);
                Debug.WriteLine("Kernel time: " + kernelTime);
                Debug.WriteLine("User time: " + userTime);
                Debug.WriteLine("Combined raw execution time: " + (kernelTime + userTime));
                long functionTime = (kernelTime + userTime) / 10000;
                Debug.WriteLine("Funciton Time: " + functionTime + " milliseconds");
            }
            static void TargetFunction()
            {
                IntPtr processHandle = GetCurrentProcess();
                bool result = DuplicateHandle(processHandle, GetCurrentThread(), processHandle, out _threadHandle, 0, false, (uint)DuplicateOptions.DUPLICATE_SAME_ACCESS);
                double value = 9876543.0d;
                for (int i = 0; i < 100000; ++i)
                    value = Math.Cos(value);
                Thread.Sleep(3000);
                value = 9876543.0d;
                for (int i = 0; i < 100000; ++i)
                    value = Math.Cos(value);
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool GetThreadTimes(IntPtr hThread,
                out System.Runtime.InteropServices.ComTypes.FILETIME lpCreationTime, out System.Runtime.InteropServices.ComTypes.FILETIME lpExitTime,
                out System.Runtime.InteropServices.ComTypes.FILETIME lpKernelTime, out System.Runtime.InteropServices.ComTypes.FILETIME lpUserTime);
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetCurrentThread();
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
                IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
                uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwOptions);
            [Flags]
            public enum DuplicateOptions : uint
            {
                DUPLICATE_CLOSE_SOURCE = (0x00000001),// Closes the source handle. This occurs regardless of any error status returned.
                DUPLICATE_SAME_ACCESS = (0x00000002), //Ignores the dwDesiredAccess parameter. The duplicate handle has the same access as the source handle.
            }
            [DllImport("kernel32.dll")]
            static extern IntPtr GetCurrentProcess();
        }
    }
