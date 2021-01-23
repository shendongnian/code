    public DataTable GetDataTable() 
    { 
        var dt = new DataTable(); 
        dt.Columns.Add("Id", typeof(string)); // dt.Columns.Add("Id", typeof(int));    
        dt.Columns["Id"].Caption ="my id"; 
        dt.Columns.Add("Name", typeof(string)); 
        dt.Columns.Add("Job", typeof(string)); 
        dt.Columns.Add("RowLabel", typeof(string));
        dt.Rows.Add(GetHeaders(dt)); 
        dt.Rows.Add(1, "Janeway", "Captain", "Label1"); 
        dt.Rows.Add(2, "Seven Of Nine", "nobody knows", "Label2"); 
        dt.Rows.Add(3, "Doctor", "Medical Officer", "Label3"); 
        return dt; 
    }
