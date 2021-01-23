    using System;
    using System.Runtime.InteropServices;
    
    
        struct Dest
        {
            public byte[] Data;
        }
    
        struct Src
        {
            public long A;
            public long B;
        }
    
        class Program
        {
            static void Main()
            {
                Copy();
            }
    
            static void Copy()
            {
                var src = new Src { A = 3, B = 4 };
                var dst = new Dest();
    
                unsafe
                {
                    Src* srcPtr = &src;
                    dst.Data = new byte[sizeof(Src)];
                    Marshal.Copy((IntPtr)srcPtr, dst.Data, 0, sizeof(Src));
                }
            }
