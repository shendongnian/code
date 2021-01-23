	string s = "12092014";
	DateTime dt;
	if(DateTime.TryParseExact(s, "ddMMyyyy",
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
