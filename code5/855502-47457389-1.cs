    const int WM_MOUSEHWHEEL = 0x020E;
    private IntPtr Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        switch (msg)
        {
            case WM_MOUSEHWHEEL:
                int tilt = (short) HIWORD(wParam);
                OnMouseTilt(tilt);
                return (IntPtr) 1;
        }
        return IntPtr.Zero;
    }
    /// <summary>
    /// Gets high bits values of the pointer.
    /// </summary>
    private static int HIWORD(IntPtr ptr)
    {
        var val32 = ptr.ToInt32();
        return ((val32 >> 16) & 0xFFFF);
    }
    /// <summary>
    /// Gets low bits values of the pointer.
    /// </summary>
    private static int LOWORD(IntPtr ptr)
    {
        var val32 = ptr.ToInt32();
        return (val32 & 0xFFFF);
    }
    private void OnMouseTilt(int tilt)
    {
        // Write your horizontal handling codes here.
    }
