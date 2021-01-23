    [DllImport("dwmapi.dll")]
    public static extern IntPtr DwmIsCompositionEnabled(out bool pfEnabled);
    
    bool aeroEnabled = false;
    
    if (NativeMethods.DwmIsCompositionEnabled(out aeroEnabled) == IntPtr.Zero)
    {
        //Some code here
    }
