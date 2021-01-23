   	public static int ClosestIndexOf(this string input, char c, int index)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		if (index < 0 || index >= input.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		var lowerInRange = true;
		var higherInRange = true;
    
		for (var i = 0; i < input.Length; i++)
		{
			if (lowerInRange)
			{
				var lower = index - i;
				lowerInRange = lower >= 0;
				if (lowerInRange && input[lower] == c)
				{
					return lower;
				}
			}
				
            if (higherInRange)
			{
				var higher = index + i;
				higherInRange = higher < input.Length;
				if (higherInRange && input[higher] == c)
				{
					return higher;
				}
			}
				
            if (!lowerInRange && !higherInRange)
			{
				break;
			}
		}
		return -1;
    }
