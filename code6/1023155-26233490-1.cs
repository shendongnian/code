    private void button2_Click(object sender, EventArgs e)
    {
      for (int i = 0; i < richTextBox1.Lines.Length; i++)
      {
        String delimitedText = richTextBox1.Lines[i];
        string[] holder = Regex.Split(delimitedText, "-");
        // Populating into datagrid
        dataGridView1.Rows.Add();
        dataGridView1.Rows[i].Cells[0].Value = holder[0].ToString();
        dataGridView1.Rows[i].Cells[1].Value = holder[1].ToString();
        dataGridView1.Rows[i].Cells[2].Value = holder[2].ToString();
        dataGridView1.Rows[i].Cells[3].Value = holder[3].ToString();
        dataGridView1.Rows[i].Cells[4].Value = holder[4].ToString();
      }
    }
