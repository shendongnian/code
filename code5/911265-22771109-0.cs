    IsAtExactInterval(new TimeSpan(10, 0, 0), new TimeSpan(1, 0, 0)); // True
    IsAtExactInterval(new TimeSpan(10, 23, 0), new TimeSpan(1, 0, 0)); // False
    
    static bool IsAtExactInterval(TimeSpan value, TimeSpan interval)
    {
        long remainder = value.Ticks % interval.Ticks;
        
        return remainder == 0;        
    }
