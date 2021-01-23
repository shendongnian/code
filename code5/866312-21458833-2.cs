    //create datatable with column FiscalMonth
    var table = new DataTable();
    table.Columns.Add("FiscalMonth");
    
    //add two rows, January and October
    var row1 = table.NewRow();
    row1["FiscalMonth"] = "January";
    var row2 = table.NewRow();
    row2["FiscalMonth"] = "October";
    table.Rows.Add(row1);
    table.Rows.Add(row2);
    
    //query from data table where FiscalMonth in (October, November, December)
    var inputParameter = new List<string> {"October", "November", "December"};
    var result = from r in table.AsEnumerable()
    			 where inputParameter.Contains(r.Field<string>("FiscalMonth"))
    			 select r.Field<string>("FiscalMonth");
    			 
    //the result will be only one row, which is October. January is successfully filtered out
    foreach (var r in result)
    {
    	Console.WriteLine(r);
    }
