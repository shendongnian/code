    using (SqlCommand command = new SqlCommand("StoredProcName", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Foo", SqlDbType.DateTime).Value = 
            new DateTime(2012, 12, 31, 16, 45, 0);
        // Execute here
    }
