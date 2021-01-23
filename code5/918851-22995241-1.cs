      public class Program
        {
    
            /// <summary>
            /// myStruct is not marshaled, directly.
            /// </summary>
            public struct myStruct
            {
    
                public int Length;
                public double[] Array;
    
    
                private IntPtr _ptr;
    
                /// <summary>
                /// Custom marshal a structure in from interop (and optionally free the original pointer).
                /// </summary>
                /// <param name="ptr"></param>
                /// <param name="freeOrig"></param>
                /// <returns></returns>
                public static myStruct MarshalIn(IntPtr ptr, bool freeOrig = true)
                {
                    byte[] by = new byte[4];
                    myStruct ns = new myStruct();
    
                    Marshal.Copy(ptr, by, 0, 4);
                    ns.Length = BitConverter.ToInt32(by, 0);
    
                    ns.Array = new double[ns.Length];
                    by = new byte[ns.Length * 8];
    
                    Marshal.Copy(ptr + IntPtr.Size, by, 0, by.Length);
                    Buffer.BlockCopy(by, 0, ns.Array, 0, by.Length);
                    if (freeOrig) Marshal.FreeHGlobal(ptr);
    
                    return ns;
                }
    
                /// <summary>
                /// Custom marshal a structure for calling interop.
                /// </summary>
                /// <returns></returns>
                public IntPtr MarshalOut()
                {
                    IntPtr ptr;
                    int l = IntPtr.Size + (8 * Array.Length);
                    ptr = Marshal.AllocHGlobal(l);
    
                    byte[] by = BitConverter.GetBytes(Length);
    
                    Marshal.Copy(by, 0, ptr, 4);
    
                    by = new byte[Length * 8];
                    Buffer.BlockCopy(Array, 0, by, 0, by.Length);
                    Marshal.Copy(by, 0, ptr + IntPtr.Size, by.Length);
    
                    _ptr = ptr;
                    return ptr;
                }
    
                /// <summary>
                /// Free any associated pointer with this structure created with MarshalOut().
                /// </summary>
                public void Free()
                {
                    if (_ptr != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(_ptr);
                        _ptr = IntPtr.Zero;
                    }
                }
            }
    
            [DllImport("mylib.dll", SetLastError = true, CharSet = CharSet.None, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr doSomething(IntPtr inStruct, double val);
    
           
            static void Main()
            {
    
                // let's do some math.
    
                myStruct ms = new myStruct(), ms2;
                ms.Array = new double[1];
    
                ms.Length = 1;
                ms.Array[0] = 424.444;
    
                ms2 = myStruct.MarshalIn(doSomething(ms.MarshalOut(), 524.444));
    
                // Free this after the call.
                ms.Free();
    
            }
        
        
        }
