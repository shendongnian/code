    private YourFunction(DataTable dt)
    {
        DataTable dt1 = new DataTable();
        foreach (DataRow row in dt.Rows)
         {
             // read item
             url_given = row["url_String"].ToString();
             var parameter = new SqlParameter("@urlGiven", SqlDbType.VarChar, url_given.Length);
             parameter.Value = url_given;
             String qrystring = "select url_String,word,count from wordcount where url_String=@urlGiven and word in (select * from temp) ";
             db.searchandorder(qrystring, dt1, parameter);
             // searchandorder is a call to a function that establishes the db connections and passes the query to the data adapter.
         }
        DoSomthingWithResults(dt1);
    }
    public void SearchAndOrder (String sql, DataTable dt, params SqlParameter[] parameters)
    {
        using(var conn = new SqlConnection(_connectionString))
        using(var da = new SqlDataAdapter(sql, conn))
        {
            da.SelectCommand.Parameters.AddRange(parameters);
            conn.Open();
            da.Fill(dt);
        }
   
        Console.Write("table coloumns" + dt.Columns.ToString());
    
        return dt;
    }
