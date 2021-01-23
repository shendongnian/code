    [DbFunction("Edm", "TruncateTime")]
	public static DateTime? TruncateTime(DateTime? dateValue)
	{
		return dateValue?.Date;
	}
