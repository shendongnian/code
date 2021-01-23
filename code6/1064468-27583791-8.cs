    // In the "admin" object.
    if (gridClients.CurrentRow == null)
    {
        MessageBox.Show("No CurrentRow is set in the source grid.");
        return;
    }
    else
    {
        // CurrentRow is set - safe to reference it.
        var adminComment = new frmAdminComment(gridClients.CurrentRow.Cells[0].Value.ToString());
        adminComment.Show();
    }
