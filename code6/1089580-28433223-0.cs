    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
        for (int i = e.RowIndex; i < e.RowCount + e.RowIndex; i++)
        {
            Console.WriteLine("Row " + i.ToString() + " added");
        }
    }
