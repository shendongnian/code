    StringBuilder sb = new StringBuilder();
    string toaddress = null;
    using (SqlConnection conn = new SqlConnection(""))
    {
        SqlCommand cmd = new SqlCommand("SELECT email FROM dbo.Members", conn);
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            sb.Append(rdr["email"].ToString() + ",");
        }
        rdr.Close();
    }
    toaddress = sb.ToString().TrimEnd(',');
