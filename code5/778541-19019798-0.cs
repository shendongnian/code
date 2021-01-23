    string start = "00:00:00";
    DayOfWeek startDay = DayOfWeek.Sunday;
    int duration = 48;
    DateTime date = DateTime.Parse(start);
    while(date.DayOfWeek != startDay)
    {
    	date = date.AddDays(1);
    }
    date = date.AddHours(duration);
    
    DayOfWeek resultDay = date.DayOfWeek;
    string time = date.ToLongTimeString();
