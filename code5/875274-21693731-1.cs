    public static bool IsApplicationIdle()
    {
        // The high-order word of the return value indicates
        // the types of messages currently in the queue. 
        return 0 == (GetQueueStatus(QS_MASK) >> 16 & QS_MASK);
    }
    const uint QS_MASK = 0x1FF;
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    static extern uint GetQueueStatus(uint flags);
