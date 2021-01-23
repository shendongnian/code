    static void Main(string[] args)
    {
        Console.WriteLine("Is 64 bits", Environment.Is64BitProcess);
        const int memory = 128 * 1024;
        var lst = new List<IntPtr>(16384); // More than necessary
        while (true)
        {
            Console.Write("{0} ", lst.Count);
            IntPtr ptr = Marshal.AllocCoTaskMem(memory);
            //IntPtr ptr = Marshal.AllocHGlobal(memory);
            lst.Add(ptr);
            if ((long)ptr < 0)
            {
                Console.WriteLine("\nptr #{0} ({1}, {2}) is < 0", lst.Count, ptr, IntPtrToUintPtr(ptr));
            }
        }
    }
