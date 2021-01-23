	public static string PrettyUrl(string s)
	{
		var tmp = Regex.Replace(RemoveDiacritics(s), "[^a-zA-Z0-9]", "-");
		return Regex.Replace(tmp, "-{2,}", "-").Trim('-');
	}
