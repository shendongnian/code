    private void Delete()
    {
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            string query = "DELETE FROM [Data] WHERE DateAdd('d', 2, [SubmittedOn]) <= Now";
            conn.Open();
            using (OleDbCommand command = new OleDbCommand(query, conn))
                command.ExecuteNonQuery();
            conn.Close();
        }
    }
