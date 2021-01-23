    var content = @"<span style=""abc"">Welcome</span><span style=""xyz"">to C#</span>";
	Regex regE = new Regex("<span[^>]*?>(.*?)</span>", RegexOptions.Singleline);
	var matches = regE.Matches(content);
	foreach (Match m in matches)
	{
		if (m.Success)
			content = content.Replace(m.Groups[0].Value, m.Groups[1].Value + " ");
	}
    content = content.Trim();
