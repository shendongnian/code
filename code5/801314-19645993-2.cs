    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace MemoryScan {
        internal class Program {
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
            private static unsafe void Main(string[] args) {
                Process process = Process.GetProcessesByName("notepad")[0]; //example target process
                int search = 100;  //search value
                int segment = 0x10000; //avoid the large object heap (> 84k)
                int range = 0x7FFFFFFF - segment; ; //32-bit example
                int bytesRead;
                List<int> addresses = new List<int>();
                DateTime start = DateTime.Now;
                for (int i = 0; i < range; i += segment) {
                    byte[] buffer = new byte[segment];
                    if (!ReadProcessMemory(process.Handle, new IntPtr(i), buffer, segment, out bytesRead)) {
                        continue;
                    }
                    IntPtr data = Marshal.AllocHGlobal(bytesRead);
                    Marshal.Copy(buffer, 0, data, bytesRead);
                    for (int j = 0; j < bytesRead; j++) {
                        int current = *(int*)(data + j);
                        if (current == search) {
                            addresses.Add(i + j);
                        }
                    }
                    Marshal.FreeHGlobal(data);
                }
                Console.WriteLine("Duration: {0} seconds", (DateTime.Now - start).TotalSeconds);
                Console.WriteLine("Found: {0}", addresses.Count);
                Console.ReadLine();
            }
        }
    }
