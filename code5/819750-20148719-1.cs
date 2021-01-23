    using (SqlConnection conn = new SqlConnection(""))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT email FROM dbo.Members", conn))
        {
            conn.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    sb.Append(rdr["email"].ToString() + ",");
                }
            }
        }
    }
