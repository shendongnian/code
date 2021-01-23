    public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            if (vkCode == VK_CAPITAL)
            {
                if (Console.CapsLock == true)
                {
                    var handler = CapsLockEnabled;
                    if (handler != null)
                    {
                        handler(typeof(MainWindow), EventArgs.Empty);
                    }
                }
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
