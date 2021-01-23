    private void button2_Click(object sender, EventArgs e)
    {
         string tableName = comboBox1WithTable.SelectedItem.ToString();
         List<string> cols = GetColumnNames(tableName);
         comboBox2WithColumns.DataSource = cols;
    }
