    public static bool IsWakeTimerSupported()
    {
            IntPtr timerHandle  = CreateWaitableTimer(IntPtr.Zero, true, "Wait Timer 1");
            long interval       = 0;
            int retVal          = 0;
            if (timerHandle != IntPtr.Zero)
            {
                SetWaitableTimer(timerHandle, ref interval, 0, IntPtr.Zero, IntPtr.Zero, true);
                retVal = Marshal.GetLastWin32Error();
                WaitableTimer.CancelWaitableTimer(timerHandle);
                try
                {
                    Win32.CloseHandle(timerHandle);
                }
                catch (Exception exp)
                {
                    Logger.LogException(exp);
                }
                timerHandle = IntPtr.Zero;
            }
            //SUCCESS
            if (retVal == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
