    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if (row.Cells["driverNo"].Value != null
                && row.Cells["driverNo"].Value.ToString() == textBox1.Text)
            {
                row.Visible = false;
            }
            else
            {
                row.Visible = true;
            }
        }
    }
