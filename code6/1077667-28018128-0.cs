	public static string ToFormattedText(this FailureDescription value)
	{
		return new string(value.ToString()
			.SelectMany(c =>
				char.IsUpper(c)
				? new [] { ' ', c }
				: new [] { c })
			.ToArray()).Trim();
	}
