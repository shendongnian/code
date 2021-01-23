    public static void JustSomeMethodToTestTheConvertion()
    {
        DateTime date = DateTime.Now.Date;
        float time = 900;
        DateTime concatDate = CombineDateAndTime(date, time);
        Console.WriteLine(concatDate);
    }
    
    public static DateTime CombineDateAndTime(DateTime date, float time)
    {
        int hours = Convert.ToInt32(Math.Round((decimal)time / 100, MidpointRounding.AwayFromZero));
        float remainder = time - (hours * 100);
        int minutes = Convert.ToInt32(Math.Round((decimal)remainder, MidpointRounding.AwayFromZero));
        return date.AddHours(hours).AddMinutes(minutes);
    }
