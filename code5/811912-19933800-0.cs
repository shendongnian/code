    private bool _isScanningCode;
    private IntPtr HookCallback(int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            if (nCode >= 0)
            {
                // Prepare the characters and retrieve the keyboard state.
                char[] characters = new char[2];
                byte[] keyState = GetKeyboardState();
                if (lParam.scanCode == 0x02)
                {
                    _isScanningCode == true;
                    return (IntPtr)1; // act like key is handled
                }
                if (lParam.scanCode == 0x03)
                {
                    _isScanningCode == false;
                    return (IntPtr)1; //act like key is handled
                }
                if (_isScanningCode)
                {
                    if (KeyPressed != null &&
                        WinAPI.ToAscii(lParam.vkCode, lParam.scanCode, keyState, characters, 0) == 1)
                    {
                        // Initialize the event arguments and fire the KeyPressed event.
                        GlobalKeyboardHookEventArgs e = new GlobalKeyboardHookEventArgs(characters, (int) wParam);
                        KeyPressed(null, e);
                        // Do not call the next hook if the event has been handled.
                        if (e.Handled)
                        {
                            return (IntPtr) 1;
                        }
                    }
                }
            }
            // Call the next hook.
            return WinAPI.CallNextHookEx(hook, nCode, wParam, ref lParam);
        }
    }
