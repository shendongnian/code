    var dt=new DataTable();
    	dt.Columns.Add("Id",typeof(int));
    	dt.Columns.Add("name",typeof(string));
    	
    	dt.Rows.Add(1,"test");
    	
    	File.WriteAllLines("C:\\test\\test.csv",
    		dt.AsEnumerable()
    			.Select(d =>
    				string.Format("{0},{1}",d.Field<int>("Id"),d.Field<string>("name")))
    		);
