    for (int i = 0; i < dataGridView1.Items.Count; i++)
    {
        TextBlock textBlock = dataGridView1.Columns[0]
                             .GetCellContent(dataGridView1.Items[i]) as TextBlock;
        if (textBlock != null)
        {
            if (String.IsNullOrEmpty(textBlock.Text))
            {
                // do something.
            }
        }
    }
