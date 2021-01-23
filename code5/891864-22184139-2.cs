	string input = "March 03 2014 abcd March 03 2014 def March 03 2014 abcd March 04 2014 xyz March 04 2014 xyz";
	List<string> dates = new List<string>();
	string[] splitted = input.Split(' ');
	for (int i = 0; i < splitted.Length; i = i + 4)
	{
		string strDate = splitted[i] + " " + splitted[i + 1] + " " + splitted[i + 2] + " " + splitted[i + 3];
		if (!dates.Contains(strDate))
		{
			dates.Add(strDate);
			if (Regex.Matches(input, strDate).Count > 1)
				Console.WriteLine(strDate + " " + Regex.Matches(input, strDate).Count);
		}
	}
