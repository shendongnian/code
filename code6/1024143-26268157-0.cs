    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            while (!Console.KeyAvailable) {
                new Wrapper();
            }
        }
    }
    class Wrapper {
        private const int alloc = 10 * 1024;    // C++ object memory usage
        private readonly bool useamp = false;   // Change this after testing
        private IntPtr mem;
    
        public Wrapper() {
            if (useamp) GC.AddMemoryPressure(alloc);
            mem = Marshal.AllocHGlobal(alloc);
        }
        ~Wrapper() {
            Marshal.FreeHGlobal(mem);
            if (useamp) GC.RemoveMemoryPressure(alloc);
        }
    }
