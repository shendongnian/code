    using(SqlConnection connection = new SqlConnection(connectionString))
    using(SqlCommand Insert = new SqlCommand("INSERT INTO database (OS) 
                                                  VALUES (@ad)", connection))
    {
        Insert.Parameters.Add("@ad", SqlDbType.NVarchar).Value = adtb.text;
        connection.Open();
        Insert.ExecuteNonQuery();
    }
