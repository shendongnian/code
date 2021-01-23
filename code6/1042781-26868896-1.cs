    private void dgvLoadTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvLoadTable.IsCurrentCellDirty)
        {
            dgvLoadTable.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
