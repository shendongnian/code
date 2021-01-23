    private DataTable getDT(string name, string[] date)
    {
        DataTable dt = new DataTable(name);
    
        dt.Columns.Add("RowID", typeof(Int16));
        dt.Columns.Add("Date", typeof(DateTime));
    
        for (int i = 0; i < date.Length; i++)    
            dt.Rows.Add(i + 1, date[i]);        
        
        return dt;
    }
