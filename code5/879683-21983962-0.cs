    double ParseAndCalc(string input)
	{
		string[] sub;
		double result = 0;
		if(input.Contains("+"))
		{
			sub = input.Split('+');
			foreach(string substring in sub)
			{
				result += ParseAndCalc(substring);
			}
		}
		else if (input.Contains("-"))
		{
			sub = input.Split('-');
			foreach(string substring in sub)
			{
				result -= ParseAndCalc(substring);
			}
		}
		else if (input.Contains("*"))
		{
			sub = input.Split('*');
			foreach(string substring in sub)
			{
				result *= ParseAndCalc(substring);
			}
		}
		else if (input.Contains("/"))
		{
			sub = input.Split('/');
			foreach(string substring in sub)
			{
				double parsed = ParseAndCalc(substring);
				if(parsed != 0)
				{
					result /= ParseAndCalc(substring);
				}
				else
				{
					// Error
				}
			}
		}
		return result;
	}
