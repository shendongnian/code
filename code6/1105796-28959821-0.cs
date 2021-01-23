    private void CustomizeCellsInThirdColumn()
    {
        int thirdColumn = 2;
        DataGridViewColumn column =
            dataGridView.Columns[thirdColumn];
        DataGridViewCell cell = new DataGridViewTextBoxCell();
    
        cell.Style.Direction = "rtl";
        column.CellTemplate = cell;
    }
