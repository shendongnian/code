    using(var cmd = new SqlCommand(query, connection))
    {
        var result = cmd.ExecuteScalar();
    
        if(result == null)
        {
            //0 rows where returned from the query
        }
        else if(result == DBNull.Value)
        {
            //Rows where returned but the value in the first column in the first row was NULL
        }
        else
        {
            //Result is the value of whatever object was in the first column in the first row
        }
    }
