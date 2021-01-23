    // Returns the DateTime resulting from adding a fractional number of
    // time units to this DateTime.
    private DateTime Add(double value, int scale) {
        long millis = (long)(value * scale + (value >= 0? 0.5: -0.5));
        if (millis <= -MaxMillis || millis >= MaxMillis) 
            throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_AddValue"));
        return AddTicks(millis * TicksPerMillisecond);
    }
