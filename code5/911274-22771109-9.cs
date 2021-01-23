    static TimeSpan Round(TimeSpan value, TimeSpan valueToRoundTo)
    {
        long factor = (value.Ticks + (valueToRoundTo.Ticks / 2) + 1) / valueToRoundTo.Ticks;
        
        return new TimeSpan(factor * valueToRoundTo.Ticks);
    }
    TimeSpan value = new TimeSpan(10, 0, 25);
    TimeSpan oneMinute = new TimeSpan(0, 1, 0);
       
    TimeSpan roundedValue = Round(value, oneMinute);
    Assert.IsTrue(new TimeSpan(10, 0, 0), roundedValue);
       
    Assert.IsTrue(IsAtExactInterval(roundedValue, new TimeSpan(1, 0, 0)));
