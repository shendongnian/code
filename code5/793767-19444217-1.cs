    private void CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && ((DataGridView)sender)[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))
        {
             int pid = Convert.ToInt32(dataGridViewVisits.Rows[e.RowIndex].Cells["Patient_ID"].Value);
             ViewR viewrepofrm = new ViewR(pid);
             viewrepofrm.MdiParent = this.ParentForm;
             viewrepofrm.Show();
        }
    }
