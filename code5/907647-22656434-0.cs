    string[] allRecords = null;
    string sql = @"SELECT CL_UnitNumber
               FROM some table";
    using (var command = new SqlCommand(sql, connection))
    {
        con.Open();
        using (var reader = command.ExecuteReader())
        {
            var list = new List<string>();
            while (reader.Read())
                list.Add(reader.GetString(0));
            allRecords = list.ToArray();
        }
    }
