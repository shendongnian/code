	public static string GetAbbreviatedScore(int value)
	{
		string result = "0";
		if (value > 0 && value < 10000)
		{
			result = value.ToString("#,#", System.Globalization.CultureInfo.CurrentUICulture);
		}
		else if (value >= 10000 && value < 100000)
		{
			if (value.ToString().EndsWith("000"))
			{
				result = value.ToString("#,#K", System.Globalization.CultureInfo.CurrentUICulture).Remove(1,4);
			}
			else
			{
			result = value.ToString("#,#K", System.Globalization.CultureInfo.CurrentUICulture).Remove(3,2);
			}
		}
		else if (value > 100000 && value < 1000000)
		{
			result = value.ToString("#,#K", System.Globalization.CultureInfo.CurrentUICulture).Remove(2,4);
		}
		return result;
	}
