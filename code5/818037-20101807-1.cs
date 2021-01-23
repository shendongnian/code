    ClassName[] allRecords = null;
    string sql = @"SELECT col1,col2
                   FROM  some table";
    using (var command = new SqlCommand(sql, con))
    {
        con.Open();
        using (var reader = command.ExecuteReader())
        {
            var list = new List<ClassName>();
            while (reader.Read())
                list.Add(new ClassName { Col1 = reader.GetString(0), Col2 = reader.GetInt32(1) });
            allRecords = list.ToArray();
        }
    }
