    DataTable dt = new DataTable();
    dt.Columns.Add("a");
    dt.Columns.Add("b");
    dt.Columns.Add("c");
    
    dt.Rows.Add("1", "01/01/2001", "01:01:2001");
    var p = from r in dt.AsEnumerable() where 
            Convert.ToDateTime(r["b"]) == Convert.ToDateTime("01/01/2001") 
            select r;
            
    System.Diagnostics.Debug.WriteLine(p.ToList()[0][0]); 
