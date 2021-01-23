    using (var conn = new OleDbConnection())
    {
        conn.ConnectionString = 
                @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=C:\Users\Public\Database1.accdb;";
        conn.Open();
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = conn;
            cmd.CommandText = 
                    "SELECT SUM(TOTAL) AS Expr1 FROM tblTicket " + 
                    "WHERE DATE_SALE>=? AND DATE_SALE<?";
            DateTime dt = dateTimePicker1.Value.Date;  // date selected
            cmd.Parameters.AddWithValue("?", dt);
            cmd.Parameters.AddWithValue("?", dt.AddDays(1));
            Object returnedValue = cmd.ExecuteScalar();
            if (DBNull.Value.Equals(returnedValue)) returnedValue = 0;
            this.textBox1.Text = returnedValue.ToString();  // display result
        }
        conn.Close();
    }
