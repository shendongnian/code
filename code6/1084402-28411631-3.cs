    if (result.IsCompleted)
    {
        try
        {
            List<string> table1 = new List<string>();
            List<string> table2 = new List<string>();
            SqlDataReader dr = ar.Sql.EndExecuteReader(result);
    
            while (dr.Read())
            {
                table1.Add(dr[0].ToString());//get data from first table
            }
    
            if (dr.NextResult())//second table
            {
                while (dr.Read())
                {
                    table2.Add(dr[0].ToString()); //get data from second table
                }
            }
    
            dr.Close();
            ar.Callback(table1 ,table2);
        }
        catch (Exception ex)
        {
            ar.Error(ex.Message);
        }
    }
