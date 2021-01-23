    DataSet ds = new DataSet();
        using(SqlConnection conn = new SqlConnection("ConnectionString"))
        {               
                SqlCommand sqlComm = new SqlCommand("usp_Test", conn);               
                sqlComm.Parameters.AddWithValue("@WhereCond", WhereCond);
    
                sqlComm.CommandType = CommandType.StoredProcedure;
    
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
    
                da.Fill(ds);
         }
