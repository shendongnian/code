To change selected rows
    private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if (null != item)
                {
                    item.DefaultCellStyle.BackColor = Color.Blue;
                }
            }            
        }
To change all rows
    foreach (DataGridViewRow item in dataGridView1.Rows)
    {
    }
