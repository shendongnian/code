    string varName = string.Format("@{0}", var);
    string sql = string.Format("SELECT * FROM Contacts WHERE {0} LIKE @{0}", var);
    using (SqlConnection c = new SqlConnection(cString))
    using (SqlCommand cmd = new SqlCommand(sql, c))
    {
        cmd.Parameters.AddWithValue(varName, textBox1.Text);
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
    }
