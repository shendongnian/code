    public class MyProxyClass
    {
        private delegate void FreeMeDelegate();
        [return:MarshalAs(UnmanagedType.I1)]
        private delegate bool DoSomethingDelegate(int value1, int value2);
        private GCHandle Handle;
        private DoSomethingDelegate DoSomething { get; set; }
        // You pass this function pointer to C++. Its signature is:
        // bool(__stdcall *DoSomething)(int32_t, int32_t)
        public IntPtr DoSomethingPtr { get; private set; }
        private FreeMeDelegate FreeMe { get; set; }
        // You have to pass this function too to C++. C++ code must use it
        // to free MyProxyClass. Its signature is:
        // void (__stdcall *FreeMe)(void)
        public IntPtr FreeMePtr { get; private set; }
        public void FreeMeImpl()
        {
            if (Handle.IsAllocated)
            {
                Handle.Free();
                DoSomething = null;
                DoSomethingPtr = IntPtr.Zero;
                FreeMe = null;
                FreeMePtr = IntPtr.Zero;
            }
        }
        public MyProxyClass(MyClass obj)
        {
            Handle = GCHandle.Alloc(this, GCHandleType.Normal);
            // This will implicitly create a reference to obj. GC can't
            // collect MyProxyClass because we have a GCHandle on it,
            // and can't collect obj because there is a delegate that
            // has a reference on it.
            DoSomething = obj.DoSomething;
            DoSomethingPtr = Marshal.GetFunctionPointerForDelegate(DoSomething);
            FreeMe = FreeMeImpl;
            FreeMePtr = Marshal.GetFunctionPointerForDelegate(FreeMe);
        }
    }
