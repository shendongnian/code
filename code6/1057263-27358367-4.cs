	StringBuilder builder = new StringBuilder();
	bool first = true;
	bool lastNumeric = true;
	bool atLeastOneNumeric = false;
	foreach (var part in urlReferrer.Split('/'))
	{
		if (part.Length > 0 && part.All(char.IsDigit))
		{
			if (!first)
				builder.Append("/");
			builder.Append(part);
			lastNumeric = true;
			atLeastOneNumeric = true;
		}
		else
		{
			lastNumeric = false;
		}
		first = false;
	}
	if (!lastNumeric && atLeastOneNumeric)
		builder.Append("/");
	urlReferrer = builder.ToString();
