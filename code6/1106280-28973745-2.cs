	public static bool TryFormatLike(this DateTime dateTime, string another, out string result)
	{
		var allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures | CultureTypes.UserCustomCulture | CultureTypes.ReplacementCultures);
		foreach (var culture in allCultures)
		{
			var allPatterns = culture.DateTimeFormat.GetAllDateTimePatterns();
			foreach (var pattern in allPatterns)
			{
				DateTime parsedAnother;
				if (DateTime.TryParseExact(another, pattern, culture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out parsedAnother))
				{
					result = dateTime.ToString(pattern);
					return true;
				}
			}
		}
		result = string.Empty;
		return false;
	}
