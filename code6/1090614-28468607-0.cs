    private void dgvRptView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (dgvRptView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
        if (dgvRptView.CurrentRow != null)
        {
            var row = dgvRptView.CurrentRow.Cells;
            DateTime age = Convert.ToDateTime(row["MyColumn"].Value);
            string name = Convert.ToString(row["MyName"].Value);
            Form Update = new frmUpdateSvcRep(age, name);
            Update.Show();
        }
    }
