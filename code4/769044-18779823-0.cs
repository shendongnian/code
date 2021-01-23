    string sql = "SELECT * INTO ##tempTable FROM (SELECT * FROM tableA)";
    using (var command = new SqlCommand(sql, connection))
    {
        command.ExecuteNonQuery(); // <-- THIS
        string sqlNew = "SELECT * FROM ##tempTable";
        using (var command2 = new SqlCommand(sqlNew, connection))
        {
            using (var reader = command2.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["column1"].ToString());
                }
                Console.ReadLine();
            }
        }
    }
