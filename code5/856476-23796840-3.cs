    public static void MouseClick(int x, int y, IntPtr handle, string Class)
    {
        StringBuilder className = new StringBuilder(100);
        while (className.ToString() != Class)
        {
            handle = GetWindow(handle, 5);
            GetClassName(handle, className, className.Capacity);
        }
        IntPtr lParam = (IntPtr)((y << 16) | x);
        IntPtr wParam = IntPtr.Zero;
        const uint downCode = 0x201;
        const uint upCode = 0x202;
        SendMessage(handle, downCode, wParam, lParam);
        SendMessage(handle, upCode, wParam, lParam);
    }
