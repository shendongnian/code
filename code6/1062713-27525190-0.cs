    private void dgvStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex != color.Index)
            return;
    
        e.CellStyle.BackColor = Color.Red;
    }
