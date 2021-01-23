    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        {
            if (dataGridView1[0, i].Value != null)
                if (dataGridView1[0, i].Value.ToString() == txtKey.Text)
                    dataGridView1[1, i].Value = txtValue.Text;
        }
    }
