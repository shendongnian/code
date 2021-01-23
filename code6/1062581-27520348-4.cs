	string s = "19-10-1924";
	DateTime dt;
	if(DateTime.TryParseExact(s, "dd-MM-yyyy", CultureInfo.GetCultureInfo("tr-TR"),
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
