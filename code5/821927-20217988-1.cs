    DateTime fromDate = dateTimePickerFrom.Value;
    DateTime toDate = dateTimePickerTo.Value;
    using (OleDbConnection conn = new OleDbConnection(connectionString))
    {
        conn.Open();
        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Product_sales WHERE From_date >= ? AND To_date <= ?", conn))
        {
            cmd.Parameters.AddWithValue("@from", fromDate);
            cmd.Parameters.AddWithValue("@to", toDate);
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    ...
            }
        }
    }
