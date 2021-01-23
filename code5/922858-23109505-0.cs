	string startdate;
	DateTime inputDate;
	while (inputDate == null)
	{
		Console.WriteLine("Input time [HH:MM TT]");
		startdate = Console.ReadLine();
		if (!DateTime.TryParseExact
		(
			startdate, "hh:mm tt"
			,CultureInfo.CurrentCulture
			,DateTimeStyles.None
			, out inputDate
		))
		{
			Console.WriteLine(String.Format("'{0}' is an invalid value."));
			//http://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx
			Console.WriteLine(
				String.Format("Example: The time now is '{0}'"
				,DateTime.Now.ToString("hh:mm tt", CultureInfo.CurrentCulture))
			);
		}
	}
	Console.WriteLine("That's a valid time :)");
	
