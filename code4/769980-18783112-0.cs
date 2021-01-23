    decimal Value = 0;
    sqlConnection2.Open();
    insertCommand2.ExecuteNonQuery();
    SqlDataReader reader2 = insertCommand2.ExecuteReader();
    
    if (reader2.HasRows)
    {
        while (reader2.Read())
        {
           Value += reader.GetDecimal(0);
        }
    }
