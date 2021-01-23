    string srcqry = "SELECT * FROM tableA";
    using (SqlConnection srccon = new SqlConnection(ConnectionString))
    using (SqlCommand srccmd = new SqlCommand(srcqry, srccon))
    {
        srccon.Open();
        using (SqlDataReader src = srccmd.ExecuteReader())
        {
            string insqry = "INSERT INTO tableB(column1) VALUES(@v1)";
            // create new connection and command for insert:
            using (SqlConnection inscon = new SqlConnection(ConnectionString))
            using (SqlCommand inscmd = new SqlCommand(insqry, inscon))
            {
                inscmd.Parameters.Add("@v1", System.Data.SqlDbType.NVarChar, 80);
                inscon.Open();
                while (rdr.Read())
                {
                    inscmd.Parameters["@v1"].Value = rdr["column1"];
                    inscmd.ExecuteNonQuery();
                }
            }
        }
    }
