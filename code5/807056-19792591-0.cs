    static Working[] DaysArray = { Working.Off, Working.Off, Working.Off, Working.Off, Working.Off, Working.Off, Working.Off, Working.Nights, Working.Nights, Working.Nights, Working.Nights, Working.Off, Working.Off, Working.Off, Working.Days, Working.Days, Working.Days, Working.Off, Working.Nights, Working.Nights, Working.Nights, Working.Off, Working.Off, Working.Off, Working.Days, Working.Days, Working.Days, Working.Days };
    public enum Working
    {
        Off,
        Days,
        Nights,
    }
    public Working GetDayNightOff(DateTime cycleStart, DateTime day)
    {
        var days = (day - cycleStart).Days;
        days %= DaysArray.Length;
        if (days < 0)
            days += DaysArray.Length;
        return DaysArray[days];
    }
