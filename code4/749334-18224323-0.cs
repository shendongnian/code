    public DataSet GetFunc()
    {
        int iRet = 0;
        DataSet ds = new DataSet();
        SqlConnection sqlConnection = new SqlConnection();
        try
        {
            iRet = connect(ref sqlConnection);
            if (DB_SUCCESS_CONNECT == iRet)
            {
                SqlCommand sqlCommand = new SqlCommand("", sqlConnection);                   
                String strQuery = "Select ID, Did, FirstName from Users";
                sqlCommand.CommandText = strQuery;
    
                SqlDataAdapter adaptor = new SqlDataAdapter(sqlCommand);
                adaptor.Fill(ds);
                sqlConnection.Close();
                return ds;                    
            }
           return null;
        }
        catch (Exception e)
        {
            disconnect(ref sqlConnection);
        }
       return null;
    }
