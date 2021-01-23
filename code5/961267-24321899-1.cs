    private void dgvSale_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvSale.IsCurrentCellDirty)
        {
            dgvSale.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
