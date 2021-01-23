	DataTable data = new DataTable();
	data.Columns.Add("ID");
	data.Columns.Add("Value");
	data.Rows.Add("1234-001", "Row 1");
	data.Rows.Add("1234-002", "Row 2");
	data.Rows.Add("1234-003", "Row 3");
	data.Rows.Add("5678-001", "Row 4");
	data.Rows.Add("7890-001", "Row 5");
	data.Rows.Add("7890-002", "Row 5");
	Dictionary<String, List<DataRow>> grouped = new Dictionary<String, List<DataRow>>();
	
	foreach(DataRow r in data.Select()) {
		List<DataRow> groupedRows;
		String key = r["ID"].ToString().Split('-')[0];
		
		if(!grouped.TryGetValue(key, out groupedRows)) {
			groupedRows = new List<DataRow>();
			grouped[key] = groupedRows;
		}
		
		groupedRows.Add(r);	
	}
	foreach(KeyValuePair<String, List<DataRow>> g in grouped) {		
		String groupKey = g.Key;
	
		Console.WriteLine(groupKey);
		foreach(DataRow r in g.Value) {
			Console.WriteLine("\t{0}", r["Value"]);
		}
	}
