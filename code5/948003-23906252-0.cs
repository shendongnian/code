	StringBuilder sb = new StringBuilder();
	int count = 0;
	for (int i = 0; i < row.Length; i++)
	{
		count++;
		if (count == 3)
		{
			sb.AppendLine(row[i])
			count = 0;
		}
		else
			sb.Append(row[i]).Append('\t');
	}
	Console.WriteLine(sb.ToString());
