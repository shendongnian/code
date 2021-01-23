		string input = "function(aa, bb, cc);";
		
		string pattern = @"\((?<str>.+)\)";
		
		Regex regex = new Regex(pattern);
		Match m = regex.Match(input);
		
		if(m.Success)
		{
			string str = m.Groups["str"].Value;
			Console.WriteLine(str);
			string[] args = str.Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
		} else {
			// unable to parse
		}
