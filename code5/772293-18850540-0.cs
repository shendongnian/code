    public static int DaysRounded(TimeSpan input, MidpointRounding rounding = MidpointRounding.AwayFromZero)
    {
        int roundupHour = rounding == MidpointRounding.AwayFromZero ? 12 : 13;
        if (input.Hours >= roundupHour)
            return input.Days + 1;
        else
            return input.Days;
    }
    int days = DaysRounded(TimeSpan.FromHours(12)); // 1 
