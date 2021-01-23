    using(SqlConnection con = new SqlConnection(conString))
    using(SqlCommand cmd = con.CreateCommand())
    {
        cmd.CommandText = "Update Players$ set [Player Name] = @name";
        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 16).Value = dataGridView2.Text;
        con.Open();
        cmd.ExecuteNonQuery();
    }
