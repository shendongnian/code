    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand sql = new SqlCommand("delete from journal where code_journal=@codeJournal AND initule=@inituleVal", connection))
        {
             cmd.Parameters.AddWithValue("@codeJournal", journalDataGridView.CurrentRow.Cells[0].Value.ToString());
             cmd.Parameters.AddWithValue("@inituleVal", journalDataGridView.CurrentRow.Cells[1].Value.ToString());
             connection.Open();
             sql.ExecuteNonQuery();
        }
    }
    
