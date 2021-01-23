    private void dataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGrid.Columns[e.ColumnIndex].Name.Equals("cResult"))
        {
            if ((String)e.Value == "FAIL")
            {
                foreach (DataGridViewCell cell in dataGrid.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.Red;
                }   
            }
        }
    }
