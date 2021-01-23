    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    SqlCommand sql = new SqlCommand("delete from journal where code_journal='" + journalDataGridView.CurrentRow.Cells[0].Value.ToString() + "'AND intitule='" + journalDataGridView.CurrentRow.Cells[1].Value.ToString() + "';", connection);
    sql.ExecuteNonQuery();
    connection.Close();
