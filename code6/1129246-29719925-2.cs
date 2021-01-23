    private YourFunction(DataTable dt)
    {
        DataTable dt1 = new DataTable();
        foreach (DataRow row in dt.Rows)
         {
             // read item
             url_given = row["url_String"].ToString();
        
             String qrystring = "select url_String,word,count from wordcount where url_String='" + url_given + "' and word in (select * from temp) ";
             db.searchandorder(qrystring, dt1);
             // searchandorder is a call to a function that establishes the db connections and passes the query to the data adapter.
         }
        DoSomthingWithResults(dt1);
    }
    public void searchandorder (String sql, DataTable dt)
    {
        conn.Open();
    
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill( dt);
    
    
        conn.Close();
        Console.Write("table coloumns" + dt.Columns.ToString());
    
        return dt;
    }
