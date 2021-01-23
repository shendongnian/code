    var sqc = new SqlCommand("SELECT C_NAME from table", con);
    using (var reader = sqc.ExecuteReader())
    {
        while (reader.Read())
        {
            int ordinal = reader.GetOrdinal("C_NAME");
            string byOrdinal = reader.GetString(ordinal);
            string byIndexer = (string)reader["C_NAME"];
 
            Console.Writeline("Column {0}, has the value of {1} (which is the same as {2})",
                ordinal, byOrdinal, byIndexer);
        }
    }
