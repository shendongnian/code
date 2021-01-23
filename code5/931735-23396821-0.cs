    public Int64 ToBinary() {
        if (Kind == DateTimeKind.Local) {
            // Local times need to be adjusted as you move from one time zone to another, 
            // just as they are when serializing in text. As such the format for local times
            // changes to store the ticks of the UTC time, but with flags that look like a 
            // local date.
        
            // To match serialization in text we need to be able to handle cases where
            // the UTC value would be out of range. Unused parts of the ticks range are
            // used for this, so that values just past max value are stored just past the
            // end of the maximum range, and values just below minimum value are stored
            // at the end of the ticks area, just below 2^62.
            TimeSpan offset = TimeZoneInfo.GetLocalUtcOffset(this, TimeZoneInfoOptions.NoThrowOnInvalidTime);
            Int64 ticks = Ticks;
            Int64 storedTicks = ticks - offset.Ticks;
            if (storedTicks < 0) {
                storedTicks = TicksCeiling + storedTicks;
            }
            return storedTicks | (unchecked((Int64) LocalMask));
        }
        else {
            return (Int64)dateData;
        }
    }  
