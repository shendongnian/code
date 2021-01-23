		string[] lines = input.Replace(Environment.NewLine, "\n").Replace('\r', '\n').Split('\n');
		for (int q = 0; q < lines.Length; q++)
		{
			string line = lines[q];
			if (string.IsNullOrWhiteSpace(line))
				continue;
			
			if (line.StartsWith("[") && line.EndsWith("]"))
			{
				string key="";
				string value="";
				
				for (int i=1; i<line.Length - 1; i++)
				{
					key=key + line[i];
				}			
				value = lines[q + 1];
				q++;
				
				dictionary.Add(key, value);
			}
		}
		
		foreach (string k in dictionary.Keys)
		{
			Console.WriteLine(k + " ==> " + dictionary[k]);
		}
