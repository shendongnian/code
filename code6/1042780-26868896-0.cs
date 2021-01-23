    private void dgvLoadTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        foreach (DataGridViewRow row in dgvLoadTable.Rows)
        {
            if (row.Cells[3].Value != null && row.Cells[3].Value.Equals(true)) //3 is the column number of checkbox
            {
                row.Selected = true;
                row.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
            }
            else
                row.Selected = false;
        }
    }
