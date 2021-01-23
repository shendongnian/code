	string s = "25-12-2014 15:35";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd-MM-yyyy HH:mm", null,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
