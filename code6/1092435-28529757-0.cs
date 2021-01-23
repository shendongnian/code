    string s = "15/02/2015";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture,
							  DateTimeStyles.None,
							  out dt))
	{
		Console.WriteLine(dt);
	}
