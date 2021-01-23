    private void btnCancelChanges_Click(object sender, EventArgs e)
    {
        DataTable DgvChangedDT = new DataTable();
        DgvChangedDT = DS1.Table1.Changes();
        if (DgvChangedDT != null && DgvChangedDT.Rows.Count != 0)
        {
            DS1.Table1.RejectChanges();
            DS1.Table1.AcceptChanges();
        }
        else
        {
            MessageBox.Show("There are no pending changes.");
        }
    }
