	// test DataTable objects for the example
	var dt1 = new DataTable("Table 1");
	dt1.Columns.Add("title", typeof(string));
	dt1.Columns.Add("number", typeof(int));
	dt1.Columns.Add("subnum1", typeof(int));
	dt1.Columns.Add("subnum2", typeof(int));
	dt1.Rows.Add(new object[] { "a", 1111, 1, 1 }); // Exact match!
	dt1.Rows.Add(new object[] { "b", 2222, 1, 1 }); // Only NUMBER match
	dt1.Rows.Add(new object[] { "b", 2222, 2, 2 }); // Only NUMBER match
	dt1.Rows.Add(new object[] { "d", 3333, 1, 1 }); // Exact match!
	dt1.Rows.Add(new object[] { "d", 3333, 1, 2 });
	dt1.Rows.Add(new object[] { "d", 3333, 2, 1 });
	var dt2 = new DataTable("Table 2");
	dt2.Columns.Add("number", typeof(int));
	dt2.Columns.Add("subnum1", typeof(int));
	dt2.Columns.Add("subnum2", typeof(int));
	dt2.Rows.Add(new object[] { 1111, 1, 1 }); // Exact match!
	dt2.Rows.Add(new object[] { 2222, 0, 5 }); // Only NUMBER match
	dt2.Rows.Add(new object[] { 3333, 1, 1 }); // Exact match!
	dt2.Rows.Add(new object[] { 3333, 0, 0 }); // Only NUMBER match
	foreach (DataRow row in dt1.Rows)
	{
		var matches = dt2.Select(string.Format("number = {0} and subnum1 = {1} and subnum2 = {2}", row["number"], row["subnum1"], row["subnum2"]));
		if (matches.Count() > 0)
		{
			Console.WriteLine(row["title"]);
		}
		else
		{
			var fallback = dt2.Select(string.Format("number = {0}", row["number"]));
			if (fallback.Count() > 0)
			{
				Console.WriteLine(" > " + row["title"]);
			}
		}
	}
