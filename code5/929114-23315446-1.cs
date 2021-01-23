    private void button1_Click(object sender, EventArgs e)
    {
        if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" )
        {
            dataGridView1.Rows.Add(1);
            dataGridView1.Rows[0].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[0].Cells[1].Value = textBox2.Text;
            dataGridView1.Rows[0].Cells[2].Value = textBox3.Text;
        }
    }
