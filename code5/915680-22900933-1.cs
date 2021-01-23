    dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
    string searchValue = "test";
    dataGridView1.Rows.ToList().ForEach(row => row.Cells.ToList().ForEach(cell => 
    {
     cell.Selected = (cell.Value != null && cell.Value.ToString().Equals(searchValue));
    }));
