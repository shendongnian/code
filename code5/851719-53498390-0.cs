        private void btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    MySqlCommand cmd = con.CreateCommand();
                    int id =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                    cmd.CommandText = "Delete from user where id='" + id+ "'";
                    dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
