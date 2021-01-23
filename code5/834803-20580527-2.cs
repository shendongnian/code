        {
        string id = "";
        con.Open();
        string sql = "SELECT MAX(id) FROM Customer";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            if(!rd.IsDBNull(0))
                id = rd.GetString(0);
        }
        con.Close();
        return id;
