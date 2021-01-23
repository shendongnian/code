    using (SqlConnection conn = new SqlConnection("YourConnectionString"))
    {
        using (SqlCommand query = new SqlCommand("select top (@topparameter) * from players order by Points desc", conn))
        {
            query.Parameters.AddWithValue("@topparameter", count.ToString());
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
            }
        }
    }
