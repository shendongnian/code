	public static bool ValidPrintRanges(string ranges)
	{
		int previousEnd = 0;
		foreach (var range in ranges.Split(','))
		{
			var pair = range.Split('-');
			int begin, end = 0;
			if (pair.Length > 2)
			{
				return false; // more than one dash
			}
			// No dash, try to parse and check to previous end
			if (pair.Length == 1)
			{
				if (!int.TryParse(range, out end)
				    || previousEnd >= end)
				{
					return false;
				}
			}
			// One dash, parse both compare to each other and to previous end
			else if (pair.Length == 2)
			{
				if (!int.TryParse(pair[0], out begin)
				    || !int.TryParse(pair[1], out end)
				    || previousEnd >= begin
				    || begin >= end)
				{
					return false;
				}
			}
			previousEnd = end;
		}
		return true;
	}
