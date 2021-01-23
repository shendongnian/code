        static void Main(string[] args)
        {
            IntPtr[] ptrArray = new IntPtr[]
            {
                Marshal.AllocHGlobal(1),
                Marshal.AllocHGlobal(2)
            };
            Marshal.WriteByte(ptrArray[0], 0, 100);
            int size = Marshal.SizeOf(typeof(IntPtr)) * ptrArray.Length;
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(ptrArray, 0, ptr, ptrArray.Length);
            // Now we have native pointer ptr, which points to two pointers,
            // each of the points to its own memory (size 1 and 2).
            // Let's read first IntPtr from ptr:
            IntPtr p = Marshal.ReadIntPtr(ptr);
            // Now let's read byte from p:
            byte b = Marshal.ReadByte(p);
            Console.WriteLine((int)b);    // prints 100
            // To do: release all IntPtr
        }
