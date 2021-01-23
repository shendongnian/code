    private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        Console.WriteLine("Clicked row: " + e.RowIndex);
        Console.WriteLine("Clicked column: " + e.ColumnIndex);
        Console.WriteLine("Cell value: " + dg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
    }
