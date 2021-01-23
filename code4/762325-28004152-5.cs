    public static unsafe bool SetBrightness(short brightness)
    {
        Graphics gr;
        gr = Graphics.FromHwnd(IntPtr.Zero);
        IntPtr hdc = gr.GetHdc(); //Use IntPtr instead of Int32, don't need private static Int32 hdc;
        ...
        ...
        //For some reason, this always returns false?
        bool retVal = SetDeviceGammaRamp(hdc, gArray);
        //Memory allocated through stackalloc is automatically free'd
        //by the CLR.
        gr.ReleaseHdc();        
        gr.Dispose();
        return retVal;
    }
