    void Main()
    {
        string k = "22.4";
        Console.WriteLine(ConvertWeekDay(k, 2014).ToString());
    }
    
    public DateTime ConvertWeekDay(string weekday, int year)
    {
        int w; int d;
        string[] wd = weekday.Split(new char[] {'.'});
        w = int.Parse(wd[0]); d = int.Parse(wd[1]);
        DateTime dt = new DateTime(year,1,1);
        while(dt.DayOfWeek != DayOfWeek.Monday)
            dt = dt.AddDays(1);
        
        dt = dt.AddDays(7 * (w - 2) + d - 1);
        return dt;
    }
