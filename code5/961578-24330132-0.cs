        if (this.isDataGridFormatted )
            return;
        foreach (DataGridViewRow row in grdComponents.Rows)
        {
            row.HeaderCell.Value = row.Cells[0].Value.ToString();
        }
        grdComponents.Columns[0].Visible = false;
        // do more stuff...
        
        this.isDataGridFormatted  = false;
         
    }
