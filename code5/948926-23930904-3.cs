    private DataTable CreateDatesTable(IEnumerable<DateTime> dates)
    {
        DataTable dt = new DataTable("Dates");
    
        dt.Columns.Add("RowID", typeof(Int16));
        dt.Columns.Add("Date", typeof(DateTime));
    
        foreach(var date in dates)        
           dt.Rows.Add(dt.Rows.Count + 1, date); 
        
        return dt;
    }
