public static class EnumExtentions
{
	public static string ToChildValue(this Gender e)
	{
		string retVal = string.Empty;
		switch (e)
		{
			case Gender.Man:
				retVal = "Boy";
				break;
			case Gender.Woman:
				retVal = "Girl";
				break;
		}
		return retVal;
	}
	public static string ToParentValue(this Gender e)
	{
		string retVal = string.Empty;
		switch (e)
		{
			case Gender.Man:
				retVal = "Dad";
				break;
			case Gender.Woman:
				retVal = "Mom";
				break;
		}
		return retVal;
	}
}
