    Regex _Regex = new Regex("\\d{5,}", RegexOptions.IgnoreCase);
    MatchCollection matchList = _Regex.Matches(strText);
    string NumberOnly = string.Empty;
    if (matchList.Count == 0)
    	NumberOnly = matchList(0).ToString();
