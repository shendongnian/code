	DateTime dateTime1 = new DateTime(2000, 01, 01, 0, 0, 0);
	DateTime dateTime2 = new DateTime(2001, 02, 02, 10, 10, 10);
	TimeSpan timeSpan1 = dateTime1 - dateTime2;
	DateTime dateTime3 = new DateTime(timeSpan1.Ticks);
	string string1 =
		dateTime3.Day + " days" +
		dateTime3.Month + " months" +
		dateTime3.Year + " years";
