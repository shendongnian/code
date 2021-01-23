    public int SelectedId { get; set; }
    private void searchdgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        this.rowIndex1 = e.RowIndex;
        this.SelectedId = Convert.ToInt32(this.searchdgv.Rows[this.rowIndex1].Cells["id"].Value);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
