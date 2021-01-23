    public bool CheckData(string sql)
    {
        using(var con = CreateConnection())
        using(var cmd = new SqlCommand(sql, con))
        {
            // ADD PARAMETERS
            con.Open();
            return cmd.ExecuteScalar() != null; // checks for a row
        }
    }
