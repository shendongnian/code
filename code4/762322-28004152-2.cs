    private static IntPtr hdc;
    private static Graphics gr;
    private static void InitializeClass()
    {
        if (initialized)
            return;
        gr = Graphics.FromHwnd(IntPtr.Zero);
        hdc = gr.GetHdc();
        initialized = true;
    }
    public static unsafe bool SetBrightness(short brightness)
    {
        InitializeClass();
        //hdc = Graphics.FromHwnd(IntPtr.Zero).GetHdc(); //You don't need it since we get the hdc once.
        ...
        ...
        //For some reason, this always returns false?
        bool retVal = SetDeviceGammaRamp(hdc, gArray);
        //Memory allocated through stackalloc is automatically free'd
        //by the CLR.
        return retVal;
    }
