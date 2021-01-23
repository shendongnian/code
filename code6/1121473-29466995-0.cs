     DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection("Your SQLConnectionString")) {
        conn.Open();
        using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT TOP 0 * FROM tabke", conn))
        {
            adapter.Fill(dt);
        };
    };
