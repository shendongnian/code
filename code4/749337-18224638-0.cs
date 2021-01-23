    public DataSet GetFunc()
    {
        string strQuery = "Select ID, Did, FirstName from Users";
        DataSet ds = new DataSet();
        using (var sqlConnection = new SqlConnection())
        using (var sqlCommand = new SqlCommand(strQuery, sqlConnection))
        using (var adaptor = new SqlDataAdapter(sqlCommand))
        {
            adaptor.Fill(ds);
        }
        return ds;
    }
