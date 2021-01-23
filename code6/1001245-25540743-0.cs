    Reason is because of @column1 appending all the time. use the below one
    parameters.Add(new SqlParameter(string.Format("@column1{0}", i), i));
        
        String query = "select * from myTable where "; // column1='1' or column1='18'
        
        var parameters = new List<SqlParameter>();
        
        for(int i = 0; i < data.Rows.Count;i++)
        {
           blah blah blah
        
           **query += " Column1='@column1' or";**
        
         --  parameters.Add(new SqlParameter("@column1", i));
             parameters.Add(new SqlParameter(string.Format("@column1{0}", i), i));
        
         }
