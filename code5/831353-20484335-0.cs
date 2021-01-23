    for (int i = 1; i <= 7; i++)
    {
	    DateTime dt = DateTime.Now;
	    dt = dt.AddDays(i - (int)DateTime.Now.DayOfWeek);
	    Console.WriteLine(dt.ToString("dddd", System.Globalization.CultureInfo.CreateSpecificCulture("en-US")));
    }
