    DateTime fromDate = dateTimePickerFrom.Value;
    DateTime toDate = dateTimePickerTo.Value;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product_sales WHERE From_date >= @from AND To_date <= @to", conn))
        {
            cmd.Parameters.AddWithValue("@from", fromDate);
            cmd.Parameters.AddWithValue("@to", toDate);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    ...
            }
        }
    }
