    //C 
    typedef unsigned long LH_TIME;
    typedef struct CallBackInterface_S{
        int (*event1) (void* inst, unsigned long type, LH_TIME timeMs);
        int (*event2) (void* inst, LH_BOOL* Continue); //continue should be set to tell the unmanaged c code if it should continue or stop.
    } CallBackInterface;
    
    //C#
    [StructLayout(LayoutKind.Sequential)]
    public struct CallBackInterface
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int event1_delegate(IntPtr inst, uint type, uint timeMs);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int event2_delegate(IntPtr inst, ref LH_BOOL Continue);
        public event1_delegate event1;
        public event2_delegate event2;
    }
