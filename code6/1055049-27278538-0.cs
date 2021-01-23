		int hours = 5;
		int minutes = 55;
		int seconds = 7;
		
		DateTime dt = new DateTime(2014, 1, 1, hours, minutes, seconds);
		
		TimeSpan ts = new TimeSpan(hours, minutes, seconds);
		
		Console.WriteLine("{0:00}:{1:00}:{2:00}", dt.Hour, dt.Minute, dt.Second);
		Console.WriteLine("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
		Console.WriteLine("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
