    public static class WaitExt
    {
        // WaitOneAndPump runs a nested message loop,
        // which is almost always a bad idea
        public static bool WaitOneAndPump(this WaitHandle handle, int timeout)
        {
            var startTick = Environment.TickCount;
            var handles = new[] { handle.SafeWaitHandle.DangerousGetHandle() };
            while (true)
            {
                // wait for the handle or a message
                var result = MsgWaitForMultipleObjectsEx(
                    1, handles,
                    (uint)(timeout == Timeout.Infinite ?
                        Timeout.Infinite :
                        Math.Max(0, timeout + startTick - Environment.TickCount)),
                    QS_ALLINPUT,
                    MWMO_INPUTAVAILABLE);
                if (result == WAIT_OBJECT_0)
                    return true; // handle signalled
                else if (result == WAIT_TIMEOUT)
                    return false; // timed-out
                else if (result != WAIT_OBJECT_0+1)
                    throw new InvalidOperationException();
                // pump messages
                Application.DoEvents();
            }
        }
        const uint QS_ALLINPUT = 0x1FF;
        const uint MWMO_INPUTAVAILABLE = 0x4;
        const uint WAIT_TIMEOUT = 0x102;
        const uint WAIT_OBJECT_0 = 0;
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint MsgWaitForMultipleObjectsEx(
            uint nCount, IntPtr[] pHandles, 
            uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
    }
