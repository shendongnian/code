    using (var con = new SqlConnection(Properties.Settings.Default.ConnectionString))
    using (var cmd = new SqlCommand("SELECT dbo.IsInteger(@value);", con))
    {
        con.Open();
        cmd.Parameters.Add("@value", SqlDbType.VarChar).Value = "10";
        bool isInt = (bool)cmd.ExecuteScalar();
    }
