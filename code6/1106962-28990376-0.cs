    private void button1_Click(object sender, EventArgs e)
    {
        DataGridViewSelectedCellCollection cells = this.dataGridView1.SelectedCells;
        foreach (DataGridViewTextBoxCell cell in cells)
        {
            Console.WriteLine("Selected cell: column: {0}  row: {1}", cell.ColumnIndex, cell.RowIndex);
        }
    }
