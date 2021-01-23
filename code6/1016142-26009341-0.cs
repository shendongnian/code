    private void enableCell(DataGridViewCell row, bool enabled) {
        //toggle read-only state
        row.ReadOnly = !enabled;
        if (enabled)
        {
            //restore cell style to the default value
            row.Style.BackColor = row.OwningColumn.DefaultCellStyle.BackColor;
            row.Style.ForeColor = row.OwningColumn.DefaultCellStyle.ForeColor;
        }
        else { 
            //gray out the cell
            row.Style.BackColor = Color.LightGray;
            row.Style.ForeColor = Color.DarkGray;
        }
    }
