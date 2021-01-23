    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IComObject))]
    public class ComObject : IComObject, ICustomQueryInterface
    {
        IntPtr _unkMarshal;
        public ComObject()
        {
            NativeMethods.CoGetStdMarshalEx(this, NativeMethods.SMEXF_SERVER, out _unkMarshal);
        }
        ~ComObject()
        {
            if (_unkMarshal != IntPtr.Zero)
            {
                Marshal.Release(_unkMarshal);
                _unkMarshal = IntPtr.Zero;
            }
        }
        // IComObject methods
        public void Test()
        {
            Console.WriteLine(new { Environment.CurrentManagedThreadId });
        }
        // ICustomQueryInterface
        public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;
            if (iid == NativeMethods.IID_IMarshal)
            {
                if (Marshal.QueryInterface(_unkMarshal, ref NativeMethods.IID_IMarshal, out ppv) != 0)
                    return CustomQueryInterfaceResult.Failed;
                return CustomQueryInterfaceResult.Handled;
            }
            return CustomQueryInterfaceResult.NotHandled;
        }
        static class NativeMethods
        {
            public static Guid IID_IMarshal = new Guid("00000003-0000-0000-C000-000000000046");
            public const UInt32 SMEXF_SERVER = 1;
            [DllImport("ole32.dll", PreserveSig = false)]
            public static extern void CoGetStdMarshalEx(
                [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
                UInt32 smexflags,
                out IntPtr ppUnkInner);
        }
    }
