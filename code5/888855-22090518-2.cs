    public void AttachHook() {
        Win32.WinEventDelegate hookDelegate = MyWinEventProcCallback;
        _hookDelegatePin = GCHandle.Alloc(hookDelegate);
        var windowsEventsHook = Win32.SetWinEventHook(
                  Win32.EVENT_SYSTEM_FOREGROUND,
                  Win32.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero,
                  _hookDelegate, 0, 0, Win32.WINEVENT_OUTOFCONTEXT);
     }
    public void MyWinEventProcCallback(...) {
    }
