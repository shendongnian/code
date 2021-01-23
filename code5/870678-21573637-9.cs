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
            else
            {
                // a message is pending 
                if (timeout == 0)
                    return false; // timed-out
                else
                {
                    // do the pumping
                    Application.DoEvents();
                    // no more messages, raise Idle event
                    Application.RaiseIdle(EventArgs.Empty);
                }
            }
        }
    }
