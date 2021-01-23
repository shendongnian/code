   
        DataTable dt = new DataTable();
        dt.Columns.Add("OrgName", typeof(string));
        dt.Columns.Add("OrgExId", typeof(string));
        dt.Columns.Add("UserName", typeof(string));
        dt.Columns.Add("UserExId", typeof(string));
        dt.Columns.Add("UserEmail", typeof(string));
	
        // put some data for testing purpose
        var id = Guid.NewGuid().ToString();
        for (var i = 0; i < 10; i++)
                dt.Rows.Add(id, i.ToString(), "user_name", Guid.NewGuid().ToString());
	
        var x = dt.Rows.Cast<DataRow>().Select(x => x.Field<string>("UserName")).Distinct();
	
        Console.WriteLine(x);
