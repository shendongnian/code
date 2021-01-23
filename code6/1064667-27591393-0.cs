	while (!reader.EndOfStream)
	{
		var line = reader.ReadLine();
		var values = line.Split('\t');
		bool deleteLine = values.Any(v => deleteCodeList.Any(w => v.Equals(w)));
		
		if (!deleteLine)
		{
			sb.Append(line + Environment.NewLine);
		}
	}
