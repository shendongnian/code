    int professorId;
    using (SqlConnection sqlConnection1 = new SqlConnection("Your Connection String"))
    using (SqlCommand cmd = new SqlCommand())
    {
        cmd.CommandText = "StoredProcedureName";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = sqlConnection1;
        sqlConnection1.Open();
    
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            // Data is accessible through the DataReader object here.
            reader.Read(); 
            professorId = reader.GetInt32(0);
        }
    }
        
