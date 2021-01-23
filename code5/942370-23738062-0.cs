    using (var conn = new MySqlConnection(connString))
    using (var cmd = new MySqlCommand(sql, conn))
    {
        var result = cmd.ExecuteScalar();
        int id;
        if (int.TryParse(result, out id))
        {
            // set the object's id here
        }
    }
