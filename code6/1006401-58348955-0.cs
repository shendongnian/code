    private void DgvSupplierInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvSupplierInfo == null)
                return;
            int sno = 1;
            string columnName = "columnName";
            string headerText = "headerText";
            if (dgvSupplierInfo.Columns.Contains(columnName))
                dgvSupplierInfo.Columns.Remove(columnName);
            {
                dgvSupplierInfo.Columns.Add(columnName, headerText);
            }
            dgvSupplierInfo.Columns[columnName].DisplayIndex = 0;
            foreach (DataGridViewRow row in dgvSupplierInfo.Rows)
                row.Cells[columnName].Value = sno++;
            dgvSupplierInfo.AutoResizeColumns();
        }
