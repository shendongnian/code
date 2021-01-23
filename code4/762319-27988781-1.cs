    private static bool initialized = false;
    private static Graphics gc;
    private static void InitializeClass()
    {
        if (initialized)
            return;
        //Get the hardware device context of the screen, we can do
        //this by getting the graphics object of null (IntPtr.Zero)
        gc = Graphics.FromHwnd(IntPtr.Zero);
        initialized = true;
    }
