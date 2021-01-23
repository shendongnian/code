    //assuming that you have a validation for your startTime that this will always on this format "HH:mm:ss"
    private static string GetEndTime(string startTime, int duration)
	{
	    string[] aStartTime = startTime.Split(':');
	    DateTime dummyStartDate = new DateTime(2013, 01, 01, Convert.ToInt32(aStartTime[0]), Convert.ToInt32(aStartTime[1]),
	        Convert.ToInt32(aStartTime[2]));
	    DateTime endDateTime = dummyStartDate.AddHours(duration);
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
	    string endTime = GetEndTime(testStartTime, duration);
	    DayOfWeek endDay = GetEndDay(duration, startDay);
	    Console.WriteLine("End Time is {0} hours on {1}", endTime, endDay.ToString());
	}
