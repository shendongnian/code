    protected void dgv_RowEnter(object sender, DataGridViewCellEventArgs  a)
    {
        EnableDisableRowCell(dgv.Rows[a.RowIndex]);
    }
    
    protected void dgc_CellValueChanged(object sender, DataGridViewCellEventArgs a)
    {
        EnableDisableRowCell(dgv.Rows[a.RowIndex]);
    }
    
    void EnableDisableRowCell(DataGridViewRow row)
    {
        string cell1=row.Cells[0].Value == null ? string.Empty : row.Cells[0].ToString();
        string cell2=row.Cells[1].Value == null ? string.Empty : row.Cells[1].ToString();
        if(string.IsNullOrWhiteSpace(cell1) && string.IsNullOrWhiteSpace(cell2))
            row.Cells[2].ReadOnly = true;
        else
            row.Cells[2].ReadOnly = false;
    }
