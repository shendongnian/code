        private void DeleteSelectedRows()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                foreach(DataGridViewRow row in dataGridView.SelectedRows)
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE ID="+row.Cells["ID"].Value, con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
