    List<string> items = new List<string>();
    using (SqlConnection conn = new SqlConnection(""))
    {
        SqlCommand cmd = new SqlCommand("SELECT email FROM dbo.Members", conn);
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            items.Add(rdr["email"].ToString());
        }
        rdr.Close();
    }
    toaddress = string.Join(",", items);
