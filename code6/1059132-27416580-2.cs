    string pattern = "(.*)(-- )(.*)( --)";
    Regex r1 = new Regex(pattern);
    foreach (string s in list)
    {
		Match match = r1.Match(s);
		if (match.Success)
		{
			string v = match.Groups[3].Value;
			Console.WriteLine("Number: {0}", v);
		}
    }
