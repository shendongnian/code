	List<DayOfWeek> listOfDays = new List<DayOfWeek>{DayOfWeek.Monday, DayOfWeek.Thursday};
	var end = new DateTime(2014,05,15);
	var day = DateTime.Now.Date;
	while (day < end)
	{
		day.AddDays(1); // adds +1 days to "day"
		if (listOfDays.Contains(day.DayOfWeek)) Console.WriteLine(day.Date.ToString());
	}
