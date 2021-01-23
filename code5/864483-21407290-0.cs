	bool first = true;
	foreach (string tbl in MyTables)
	{
		if (first)
		{
			SQLQuery.AppendLine("UNION");
			first = false;
		}
		SQLQuery.Append("SELECT [col1], [col2], [col3] FROM ");
		SQLQuery.AppendLine(tbl);
	}
