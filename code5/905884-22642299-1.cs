    using System;
    using System.Runtime.InteropServices;
    
    
        struct Dest
        {
            public byte[] Data;
        }
    
        struct Src
        {
            public GCHandle StringHandle;
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
                var str = "Hello";
                var src = new Src { 
                    A = 3, 
                    B = 4, 
                    StringHandle = GCHandle.Alloc(str, GCHandleType.Normal) 
                };
                var dst = new Dest();
    
                unsafe
                {
                    Src* srcPtr = &src;
                    dst.Data = new byte[sizeof(Src)];
                    Marshal.Copy((IntPtr)srcPtr, dst.Data, 0, sizeof(Src));
                }
                // When you're sure no one can reference the string anymore
                // (Including by accessing the data you put in dst.Data!)
                src.StringHandle.Free();
            }
