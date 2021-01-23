    string queryStr = "YOUR SQL QUERY HERE";
    SqlCommand cmd = new SqlCommand(queryStr, new SqlConnection(connectionString));
    cmd.Connection = sqlConnection;
    sqlConnection.Open();
    cmd.ExecuteNonQuery();
    sqlConnection.Close();
