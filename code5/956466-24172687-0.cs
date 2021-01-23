    DataGridViewRow row = journalDataGridView.SelectedRows[0];
    connection.Open();
    using (SqlCommand sql = new SqlCommand("delete from journal where code_journal=@codeJournal..", connection)) {
      sql.Parameters.AddWithValue("@codeJournal", row.Cells[0].Value.ToString());
      sql.ExecuteNonQuery();
    }
    connection.Close();
    journalDataGridView.Rows.Remove(row);
