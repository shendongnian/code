    var sql = string.Format(
        "UPDATE {0}_Animals SET Stock = Stock - 1 WHERE Specie = @Specie",
            ddlcountry.Text);
    using (MySqlConnection c = new MySqlConnection(cString))
    using (MySqlCommand cmd = new MySqlCommand(sql, c))
    {
        c.Open();
        cmd.Parameters.AddWithValue("@Specie", specie);
        cmd.ExecuteNonQuery();
    }
