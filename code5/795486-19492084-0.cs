    DataTable table = new DataTable();
    table.Columns.Add("id", typeof(int));
    table.Columns.Add("Test", typeof(string));
    table.Columns.Add("ValueToChange", typeof(string));
	
    table.Rows.Add(1, "1");
    table.Rows.Add(2, "0");
    table.Rows.Add(3, "1");
    table.Rows.Add(4, "0");
    table.Rows.Add(5, "1");
    //Select all Rows in which the column Test is "1"
    var rows = table.AsEnumerable().Where (t => t.Field<string>("Test") == "1");
    foreach (var x in rows)
    {
        //set the field ValueToChange to "changed"
 	    x.SetField("ValueToChange", "changed");
        //linqpad output. ignore it
	    x.Dump();
    }
