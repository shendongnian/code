    private DataTable getDT(string[] date)
    {
        DataTable dt = new DataTable();
    
        dt.Columns.Add("RowID", typeof(Int16));
        dt.Columns.Add("Date", typeof(DateTime));
    
        if (date != null)
        {
            for (int i = 0; i < date.Length; i++)    
                 dt.Rows.Add(i + 1, date[i]);
        }
        
        return dt;
    }
