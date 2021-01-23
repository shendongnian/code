    const long TicksPerSecond = 10000000L;
    const long TicksPer1Hour = TicksPerSecond * 3600;
    const long TicksPer3Hours = TicksPer1Hour * 3;
    const long TicksPer6Hours = TicksPer1Hour * 6;
	const long TicksPerDay = TicksPer1Hour * 24;
    
    private static long GetDiffFrom6Hours(DateTime time)
    {
    	return Math.Abs(TicksPer3Hours - Math.Abs(((time.Ticks % TicksPerDay) + TicksPer3Hours) % TicksPer6Hours));
    }
