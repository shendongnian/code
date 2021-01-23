    public void Main()
    {
		var s1 = "μ";
		var s2 = "µ";
		Console.WriteLine(s1.Equals(s2));  // false
		Console.WriteLine(RemoveDiacritics(s1).Equals(RemoveDiacritics(s2))); // true 
    }
	
	static string RemoveDiacritics(string text) 
	{
		var normalizedString = text.Normalize(NormalizationForm.FormKC);
		var stringBuilder = new StringBuilder();
	
		foreach (var c in normalizedString)
		{
			var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
			if (unicodeCategory != UnicodeCategory.NonSpacingMark)
			{
				stringBuilder.Append(c);
			}
		}
	
		return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
	}
