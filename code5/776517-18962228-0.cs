    DataTable dt = new DataTable();
    using (SqlConnection c = new SqlConnection(cString))
    using (SqlDataAdapter sda = new SqlDataAdapter(sql, c))
    {
        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
        sda.SelectCommand.Parameters.AddWithValue("@parm1", val1);
        ...
        sda.Fill(dt);
    }
