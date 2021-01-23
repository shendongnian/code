    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void SetTextDel([MarshalAs(UnmanagedType.BStr)] string value);
    
    [ComVisible(true), Guid("81C99F84-AA95-41A5-868E-62FAC8FAC263"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface Icom
    {
        void Set([MarshalAs(UnmanagedType.FunctionPtr)] SetTextDel del);
    }
    
    [ComVisible(true)]
    [Guid("6DF6B926-8EB1-4333-827F-DD814B868097")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(Icom))]
    public class B : Icom
    {
        public void Set(SetTextDel del)
    	{
    		del("some text");
    	}
    }
