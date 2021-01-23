        using(SqlCommand sqlCommand = new SqlCommand(SQL, sqlConnection))
        {
             sqlCommand.Parameters.Add("@customer_Name", SqlDbType.VarChar, 100).Value = customer_Name;
             sqlConnection.Open();
             int customer_Id = (int)sqlCommand.ExecuteScalar();
             sqlConnection.Close();
        }
