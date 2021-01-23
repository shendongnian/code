    public static class WaitExt
    {
        // WaitOneAndPump runs a nested message loop,
        // which is almost always a bad idea!!
        public static bool WaitOneAndPump(this WaitHandle handle, int timeout)
        {
            var startTick = Environment.TickCount;
            var handles = new[] { handle.SafeWaitHandle.DangerousGetHandle() };
            while (true)
            {
                // wait for a handle or a message
                uint result = MsgWaitForMultipleObjectsEx(
                    1, handles,
                    (uint)(timeout == Timeout.Infinite ?
                        Timeout.Infinite :
                        Math.Max(0, timeout + startTick - Environment.TickCount)),
                    0x1FF, // QS_ALLINPUT
                    0x0004); // MWMO_INPUTAVAILABLE
                if (result == 0) // WAIT_OBJECT_0
                    return true; // handle signalled
                if (result == 0x00000102) // WAIT_TIMEOUT
                    return false; // timed-out
                if (result != 1)
                    throw new InvalidOperationException();
                // pump messages
                Application.DoEvents();
            }
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint MsgWaitForMultipleObjectsEx(
            uint nCount, IntPtr[] pHandles, uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
    }
