    private void button1_Click(object sender, EventArgs e)
    {
        dataGridView1.Rows.Add();
        dataGridView1.Rows[0].Cells["Name"].Value = textBox1.Text;
        dataGridView1.Rows[0].Cells["price"].Value = textBox2.Text;
        dataGridView1.Rows[0].Cells["qty"].Value = textBox3.Text;
        dataGridView1.Rows[0].Cells["Total"].Value = Math.Round(Convert.ToDecimal(dataGridView1.Rows[0].Cells["price"].Value) * Convert.ToDecimal(dataGridView1.Rows[0].Cells["qty"].Value), 2);
    }
