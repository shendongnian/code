    var toaddress = new StringBuilder();
    var delimiter = "";
    using (SqlConnection conn = new SqlConnection(""))
    {
        SqlCommand cmd = new SqlCommand("SELECT email FROM dbo.Members", conn);
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            toaddress.AppendFormat("{0}{1}", delimiter, rdr["email"].ToString());
            delimiter = ",";
        }
        rdr.Close();
    }
    return toaddress.ToString();
