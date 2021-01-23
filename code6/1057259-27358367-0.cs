	StringBuilder builder = new StringBuilder();
	bool first = true;
	bool lastNumeric = true;
	foreach (var part in urlReferrer.Split('/'))
	{
		if (part.All(char.IsDigit))
		{
			if (!first)
				builder.Append("/");
			builder.Append(part);
			lastNumeric = true;
		}
		else
		{
			lastNumeric = false;
		}
		first = false;
	}
	if (!lastNumeric)
		builder.Append("/");
	urlReferrer = builder.ToString();
