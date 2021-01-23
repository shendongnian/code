        while (dataGridView1.ColumnCount < checkedListBox1.CheckedItems.Count)
               dataGridView1.Columns.Add("", "");
        int newRow = dataGridView1.Rows.Add();
        int item = 0;
        foreach ( object o in checkedListBox1.CheckedItems)
        {
            dataGridView1[newRow, item].Value = o.ToString();
            item ++;
        }
