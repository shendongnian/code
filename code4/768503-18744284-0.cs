    deleteButton.Click += new System.EventHandler(this.DeleteRecord);
    
    private DeleteRecord(object sender, EventArgs e)
    {
    
    foreach(DataGridViewRow row in DataGridView1.SelectedRows)
    {
        int rowIdToDelete = row.Cells[ID].Value;
        using (OleDbConnection conn = new OleDbConnection(connectionString))
                        {
                            string query = "DELETE FROM [Record] WHERE ID = " + rowIdToDelete;
                            conn.Open();
    
                            using (OleDbCommand cmd = new OleDbCommand(query, conn))
                            {
                                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                                {
                                    DataTable ds = new DataTable();
                                    adapter.Update(ds);
                                    dataGridView.DataSource = ds;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
    }
    
    }
