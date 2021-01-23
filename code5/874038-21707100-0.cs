    List<string> replacementValues = new List<string> 
		{ 
			"lts", "mts", 
			"cwts", "rotc"
		};
    string[] tokens = val.Split(new char[] { ' ' }, StringSplitOptions.None);
    string result = string.Join(" ", tokens.Select(t =>
                {
                    // Now split by "/"
                    string[] ts = t.Split(new char[] { '/' }, StringSplitOptions.None);
                    if (ts.Count() > 1)
                    {
                        t = string.Join("/", ts.Select(x => replacementValues.Contains(x.ToLower()) ? x.ToUpper() : x));
                    }
                    return t;
                }));
