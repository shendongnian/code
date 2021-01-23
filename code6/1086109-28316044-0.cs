    public void GetDate(string dateString)
    {
	DateTime result;
	CultureInfo provider = CultureInfo.InvariantCulture;
	string format = "d";
	try
	{
		if(DateTime.TryParseExact(dateString,provider, DateTimeStyles.None, out result))
		{
			Console.WriteLine("{0} converts to {1}", dateString, result.ToString());
		}
		else
		{
			Console.WriteLine("{0} is not in the correct format", dateString);
		}
	}
	catch(FormatException)
	{
		Console.WriteLine("{0} is not in the correct format", dateString);
	}
    }
