    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            ulong start, end;
            start = NativeMethods.GetThreadCycles();
            System.Threading.Thread.Sleep(1000);
            end = NativeMethods.GetThreadCycles();
            ulong cycles = end - start;
            Debug.Assert(cycles < 200000);
        }
    
        static class NativeMethods {
            public static ulong GetThreadCycles() {
                ulong cycles;
                if (!QueryThreadCycleTime(PseudoHandle, out cycles))
                    throw new System.ComponentModel.Win32Exception();
                return cycles;
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool QueryThreadCycleTime(IntPtr hThread, out ulong cycles);
            private static readonly IntPtr PseudoHandle = (IntPtr)(-2);
    
        }
    }
