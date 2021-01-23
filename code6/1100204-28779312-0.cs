    public sealed class ArrayToIntPtr : IDisposable
    {
        public IntPtr Ptr { get; protected set; }
        public ArrayToIntPtr(Array input)
        {
            if (input != null)
            {
                int s = Marshal.SizeOf(input.GetValue(0).GetType()) * input.Length;
                Ptr = Marshal.AllocHGlobal(s);
            }
            else
            {
                Ptr = IntPtr.Zero;
            }
        }
        ~ArrayToIntPtr()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        protected void Dispose(bool disposing)
        {
            if (Ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(Ptr);
                Ptr = IntPtr.Zero;
            }
            if (disposing)
            {
                GC.SuppressFinalize(this);
            }
        }
    }
