	using (StreamReader file = new StreamReader("test.txt"))
	{
		while ((line = file.ReadLine()) != null)
		{
			foreach (string word in words)
			{
				if (line.Contains(word))
				{
					sb.AppendLine(line);
				}
			}
		}
	}
