    // Check if a row is selected.
    // In the "admin" object.
    if (gridClients.SelectedRows.Length == 0)
    {
        MessageBox.Show("No rows selected in the source grid.");
    }
    else
    {
        // CurrentRow is set - safe to reference it.
        var adminComment = new frmAdminComment(gridClients.SelectedRows[0].Cells[0].Value.ToString());
        adminComment.Show();
    }
