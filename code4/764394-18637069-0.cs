    var dt = new DataTable();
    using (SqlConnection c = new SqlConnection(cString))
    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT ...", c))
    {
        sda.SelectCommand.Parameters.AddWithValue("@field1", field1);
        etc...
        sda.Fill(dt);
    }
