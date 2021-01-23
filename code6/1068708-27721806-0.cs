    using(SqlCommand cmd = new SqlCommand(
        "SELECT * FROM [App].[Version] WHERE ID = @ID", conn))
    {
        cmd.Parameters.Add(new SqlParameter("@ID", ID));
        using(var rdr = cmd.ExecuteReader()
        {
            while (rdr.Read())
            {
                var id = rdr.GetInt32(0);
                var name = rdr.GetString(1);
                // etc
            }
        }
    }
