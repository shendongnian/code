    using (SqlConnection sqlConnection = new SqlConnection(ClassGlobal.ConnectionString))
    {       
        sqlConnection.Open();
        using (SqlCommand sqlCommand1 = new SqlCommand("SQL code here", sqlConnection))
        {
            sqlCommand1.ExecuteNonQuery();
        }
        using (SqlCommand sqlCommand2 = new SqlCommand("SQL code here", sqlConnection))
        {
            sqlCommand2.ExecuteNonQuery();
        }
        // ...
        sqlConnection.Close();
    
        ClassGlobal.WriteAction(action);
        // ... perhaps open it again here
    }
