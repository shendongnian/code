    public static TimeSpan operator -(DateTime d1, DateTime d2)
    {
    	return new TimeSpan(d1.InternalTicks - d2.InternalTicks);
    }
    public TimeSpan Subtract(DateTime value)
    {
    	return new TimeSpan(this.InternalTicks - value.InternalTicks);
    }
