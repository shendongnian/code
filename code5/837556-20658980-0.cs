    using (var c = new SqlConnection())
    { 
        using (var cmd = new SqlCommand("select code from test where name = @name", c))
        {
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            c.Open();
            int code = (int)cmd.ExecuteScalar();
        }
    }
