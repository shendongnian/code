    private void dgvLoadData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvLoadData.IsCurrentCellDirty)
        {
            dgvLoadData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
