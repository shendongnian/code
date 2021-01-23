    public static class WaitExt
    {
        // WaitOneAndPump runs a nested message loop,
        // which is almost always a bad idea
        public static bool WaitOneAndPump(
            this WaitHandle handle, int millisecondsTimeout)
        {
            var startTick = Environment.TickCount;
            var handles = new[] { handle.SafeWaitHandle.DangerousGetHandle() };
            while (true)
            {
                // wait for the handle or a message
                var timeout = (uint)(Timeout.Infinite == millisecondsTimeout ?
                        Timeout.Infinite :
                        Math.Max(0, millisecondsTimeout + 
                            startTick - Environment.TickCount));
                var result = MsgWaitForMultipleObjectsEx(
                    1, handles,
                    timeout,
                    QS_ALLINPUT,
                    MWMO_INPUTAVAILABLE);
                if (result == WAIT_OBJECT_0)
                    return true; // handle signalled
                else if (result == WAIT_TIMEOUT)
                    return false; // timed-out
                else if (result == WAIT_ABANDONED_0)
                    throw new AbandonedMutexException(-1, handle);
                else if (result != WAIT_OBJECT_0 + 1)
                    throw new InvalidOperationException();
                // one or more messages are pending, do pumping
                Application.DoEvents();
                // no more messages, raise Idle event
                Application.RaiseIdle(EventArgs.Empty);
            }
        }
        const uint QS_ALLINPUT = 0x1FF;
        const uint MWMO_INPUTAVAILABLE = 0x4;
        const uint WAIT_TIMEOUT = 0x102;
        const uint WAIT_OBJECT_0 = 0;
        const uint WAIT_ABANDONED_0 = 0x80;
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint MsgWaitForMultipleObjectsEx(
            uint nCount, IntPtr[] pHandles,
            uint dwMilliseconds, uint dwWakeMask, uint dwFlags);
    }
