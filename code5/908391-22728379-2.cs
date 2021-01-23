    public struct apData_T
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public IntPtr[] data;
    }
    public delegate void VideoCaptureCB_Ptr(
        IntPtr pContext,
        apData_T apData, 
        ref VideoSampleInfo_T pVSI
    );
