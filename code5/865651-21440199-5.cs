	using (StreamReader file = new StreamReader("test.txt"))
	{
		foreach (string word in words)
		{
			while ((line = file.ReadLine()) != null)
			{
				if (line.Contains(word))
				{
					sb.AppendLine(line);
				}
			}
			
			if (sb.Length == 0)
			{
				// Rewind file to prepare for next word
				file.Position = 0;
				file.DiscardBufferedData();   
			}
			else
			{
				return sb.ToString();
			}
		}
	}
