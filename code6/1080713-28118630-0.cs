    string a;
    string b;
    string c;
    foreach (DataTable table in ds.Tables)
	{
		foreach (DataRow row in table.Rows)
		{
			var arr = row.ItemArray;
			if (arr.Length > 2){
				a = (string)arr[0];
				b = (string)arr[1];
				c = (string)arr[2];
			}
		}
	}
