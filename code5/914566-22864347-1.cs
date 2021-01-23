    string query = "SELECT dbo.BusinessMinutes(@start,@end,@priorityid)";
    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
        cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
        cmd.Parameters.Add("@priorityid", SqlDbType.UniqueIdentifier).Value = priorityId;                    
        // assuming connection is already open
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read()) minutes = reader.GetInt32(0);
        }
    }
