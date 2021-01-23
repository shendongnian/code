    public string GetDGVHeaderText(int index)
    {
        if (index < dataGridView1.ColumnCount)
        {
            return dataGridView1.Columns[index].HeaderText;
        }
        else
        {
            return string.Empty;
        }
    }
