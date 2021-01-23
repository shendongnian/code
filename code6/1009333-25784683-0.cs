	DateTime samp = new DateTime(2013, 05, 18);
	Console.WriteLine(string.Format("Ticks: {0}", samp.Ticks));
	Console.WriteLine(string.Format("The day of the week as a number: {0}", (samp.Ticks / 864000000000L + 1L) % 7L)); // The formula they use to calculate day of week
	Console.WriteLine(samp.DayOfWeek);
	Console.ReadLine();
