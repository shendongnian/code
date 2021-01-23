    private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString() == "2")
                    {
                    //To colour the row
                    row.DefaultCellStyle.BackColor = Color.Red;
                    //To select the row
                    row.Selected = true;
                    }
                }
            }
