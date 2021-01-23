    string txt = "department_name:womens AND item_type_keyword:base-layer-underwear";
    var reg = new Regex(@"(?:department_name|item_type_keyword):([\w-]+)", RegexOptions.IgnoreCase);
    var ms = reg.Matches(txt);
    ArrayList results = new ArrayList();
    foreach (Match match in ms)
    {
        results.Add(match.Groups[0].Value);
        results.Add(match.Groups[1].Value);
    }
    // results is your final array containing all results
    foreach (string elem in results)
	{
		Console.WriteLine(elem);
	}
