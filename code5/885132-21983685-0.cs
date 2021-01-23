	var dt1 = new DataTable();
	var prime1 = dt1.Columns.Add("Tag", typeof(string));
	dt1.Columns.Add("Value", typeof(string));
	dt1.Rows.Add(new object[]{"abc", "default"});
	dt1.Rows.Add(new object[]{"xyz", "default"});
	dt1.PrimaryKey = new DataColumn[]{ prime1 };
	
	var dt2 = new DataTable();
	var prime2 = dt2.Columns.Add("Tag", typeof(string));
	dt2.Columns.Add("Value", typeof(string));
	dt2.Rows.Add(new object[]{"abc", "12"});
	dt2.PrimaryKey = new DataColumn[]{ prime2 };
	
	dt1.Merge(dt2);
