	// test DataTable objects for the example
	var dt1 = new DataTable("test");
	dt1.Columns.Add("title", typeof(string));
	dt1.Columns.Add("number", typeof(int));
	dt1.Columns.Add("subnum1", typeof(int));
	dt1.Columns.Add("subnum2", typeof(int));
	dt1.Rows.Add(new object[] { "a", 1, 1, 1 });
	dt1.Rows.Add(new object[] { "a", 2, 1, 2 });
	dt1.Rows.Add(new object[] { "b", 3, 3, 2 }); // match!
	dt1.Rows.Add(new object[] { "c", 4, 4, 5 });
	var dt2 = new DataTable("test");
	dt2.Columns.Add("number", typeof(int));
	dt2.Columns.Add("subnum1", typeof(int));
	dt2.Columns.Add("subnum2", typeof(int));
	dt2.Rows.Add(new object[] { 5, 1, 1 });
	dt2.Rows.Add(new object[] { 6, 1, 4 });
	dt2.Rows.Add(new object[] { 3, 3, 2 }); // match!
	dt2.Rows.Add(new object[] { 7, 8, 9 });
	// create filter and apply it for every combination
	// of table1 to the whole table 2 set
	foreach (DataRow row in dt1.Rows)
	{
		var matches = dt2.Select(string.Format("number = {0} and subnum1 = {1} and subnum2 = {2}", row["number"], row["subnum1"], row["subnum2"]));
		if (matches.Count() > 0)
		{
			Console.WriteLine(row["title"]);
		}
	}
