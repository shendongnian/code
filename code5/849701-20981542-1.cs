    [StructLayout(LayoutKind.Sequential)]
    public class SET_PROFILE
    {
        public int x;
        public int y;
        public System.IntPtr orange;    
        public string OrangeString { get { return Marshal.PtrToStringAnsi(orange); } }
    }
