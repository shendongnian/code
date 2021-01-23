    DataTable dt1 = new DataTable();
    DataColumn dc = new DataColumn("id", System.Type.GetType("System.Int32"));
    dt1.Columns.Add(dc);
    dc = new DataColumn("name", System.Type.GetType("System.String"));
    dt1.Columns.Add(dc);
    dt1.Rows.Add(new Object[]{1, "Peter"});
    dt1.Rows.Add(new Object[]{2, "John"});
    
    
    DataTable dt2 = new DataTable();
    dc = new DataColumn("id", System.Type.GetType("System.Int32"));
    dt2.Columns.Add(dc);
    dc = new DataColumn("address", System.Type.GetType("System.String"));
    dt2.Columns.Add(dc);
    dt2.Rows.Add(new Object[]{1, "123 ave"});
    dt2.Rows.Add(new Object[]{2, "456 blvd"});
    
    DataTable dt3 = new DataTable();
    dc = new DataColumn("id", System.Type.GetType("System.Int32"));
    dt3.Columns.Add(dc);
    dc = new DataColumn("address", System.Type.GetType("System.Int32"));
    dt3.Columns.Add(dc);
    dt3.Rows.Add(new Object[]{1, 1});
    dt3.Rows.Add(new Object[]{1, 2});
    dt3.Rows.Add(new Object[]{2, 1});
    dt3.Rows.Add(new Object[]{2, 2});
    
    var qry = from refdata in dt3.AsEnumerable()
    		join userdata in dt1.AsEnumerable() on refdata.Field<int>("id") equals userdata.Field<int>("id")
    		join addressdata in dt2.AsEnumerable() on refdata.Field<int>("id") equals addressdata.Field<int>("id")
    		select new
    		{
    			uid = userdata.Field<int>("id"),
    			uname = userdata.Field<string>("name"),
    			aid = addressdata.Field<int>("id"),
    			aadress = addressdata.Field<string>("address")
    		};
