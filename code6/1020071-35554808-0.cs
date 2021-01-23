    static class GenericValueConverter
    {
		public static bool TryParse<T>(this string input, out T result)
		{
			bool isConversionSuccessful = false;
			result = default(T);
			var converter = TypeDescriptor.GetConverter(typeof(T));
			if (converter != null)
			{
				try
				{
					result = (T)converter.ConvertFromString(input);
					isConversionSuccessful = true;
				}
				catch { }
			}
			return isConversionSuccessful;
		}
    }
    void Main()
    {
		double pi;
		if (GenericValueConverter.TryParse("3,14159", out pi)) //Use right decimal point seperator for local culture
		{
			pi.Dump(); //ConsoleWriteline for LinqPad
			//pi=3,14159
		}
		string dtStr = "2016-12-21T16:34:22";
		DateTime dt;
		if (dtStr.TryParse(out dt))
		{
			dt.Dump(); //ConsoleWriteline for LinqPad
			//dt=21.12.2016 16:34:22
		}
		string guidStr = "D430831B-03B0-44D5-A971-4E73AF96B5DF";
		Guid guid;
		if (guidStr.TryParse(out guid))
		{
			guid.Dump(); //ConsoleWriteline for LinqPad
			//guid=d430831b-03b0-44d5-a971-4e73af96b5df
		}
    }
