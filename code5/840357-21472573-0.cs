    SqlConnection connection = new SqlConnection("connection string");
    SqlCommand sqlcmd = new SqlCommand("spGetValue", connection);
    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
    SqlParameter pField = sqlcmd.Parameters.Add("@Field", System.Data.SqlDbType.NVarChar, 50);
    pField.Value = "value here";
    connection.Open();
    SqlDataReader reader = sqlcmd.ExecuteReader();
