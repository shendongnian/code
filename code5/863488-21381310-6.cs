    using (var con = new SqlConnection("ConnectionString"))
    {
        con.Open();
        foreach (DataRow row in tblCSV.Rows)
        {
            using (var cmd = new SqlCommand("INSERT INTO table(Col1,Col2) VALUES (@Col1,Col2);", con))
            {
                string col1 = row.Field<string>("Col1");
                if (string.IsNullOrWhiteSpace(col1))
                    col1 = null;
                string col2 = row.Field<string>("Col2");
                if (string.IsNullOrWhiteSpace(col2))
                    col2 = null;
                cmd.Parameters.AddWithValue("@col1", col1);
                cmd.Parameters.AddWithValue("@col2", col2);
                int inserted = cmd.ExecuteNonQuery();
            }
        }
    }
