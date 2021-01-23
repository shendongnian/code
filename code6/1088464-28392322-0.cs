    DataTable dt = new DataTable("myTable");
    dt.Columns.Add("id", typeof (int));
    dt.Columns.Add("name", typeof (string));
    DataRow row = dt.NewRow();
    row["id"] = 1;
    //row["name"] = "";
    dt.Rows.Add(row);
    row = dt.NewRow();
    row["id"] = 0;
    //row["name"] = "zzz";
    dt.Rows.Add(row);
    row = dt.NewRow();
    row["id"] = 2;
    //row["name"] = "222";
    dt.Rows.Add(row);
    dt.Dump();
    
    bool IsColumnEmpty=	 dt.AsEnumerable().All(dr=>string.IsNullOrEmpty( dr["name"]+""));
    Console.WriteLine (IsColumnEmpty);
