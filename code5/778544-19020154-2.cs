    //assuming that you have a validation for your startTime that this will always on this format "HH:mm:ss"
    private static string GetEndTime(string startTime, int duration, DayOfWeek dayOfWeek)
	{
	    DateTime startDateTime = DateTime.Parse(startTime);
	    DateTime endDateTime = startDateTime.AddHours(duration);
	    return endDateTime.ToString("HH:mm:ss");
	}
	private static DayOfWeek GetEndDay(int duration, DayOfWeek dayOfWeek)
	{
	    int days = duration / 24;
	    DayOfWeek endDay = dayOfWeek + days;
	    return endDay;
	}
	static void Main()
	{
	    string testStartTime = "00:00:00";
	    DayOfWeek startDay = DayOfWeek.Sunday;
	    int duration = 48;
	    string endTime = GetEndTime(testStartTime, duration, startDay);
	    DayOfWeek endDay = GetEndDay(duration, startDay);
        Console.WriteLine("End Time is {0} hours on {1}", endTime, endDay.ToString());
	}
