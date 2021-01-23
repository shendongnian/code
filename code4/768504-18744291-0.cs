      using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM [Record] WHERE ID =" + idTextBox.Text;
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
