    static int GetLastInputTime()
    {
        uint idleTime = 0;
        LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
        lastInputInfo.cbSize = Marshal.SizeOf( lastInputInfo );
        lastInputInfo.dwTime = 0;
        uint envTicks = (uint)Environment.TickCount;
        if ( GetLastInputInfo( ref lastInputInfo ) )
        {
            uint lastInputTick = lastInputInfo.dwTime;
            idleTime = envTicks - lastInputTick;
        }
        return (( idleTime > 0 ) ? ( idleTime / 1000 ) : 0);
    }
