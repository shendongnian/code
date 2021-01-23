	public static int GetModifiedCommaCount(string searchString)
	{
		int result = 0;
		int lastIndex = searchString.Length - 1;
		// start looping at our first match to save time
		for (int i = searchString.IndexOf(','); i <= lastIndex && i > 0; i++)
		{
			if (searchString[i] == ',' && (i >= lastIndex || searchString[i + 1] == '0' || searchString[i + 1] == '#'))
			{
				result++;
			}
		}
		return result;
	}
