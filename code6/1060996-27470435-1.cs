        private void dgvProjectDetails__CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            var cell = ((DataGridView)sender)[col, row];
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                frmAddProjects ProjectDetail = new frmAddProjects(); //<= THIS must be created first
                ProjectDetail.projectid = row.Cells["ProjectID"].Value.ToString();
                ProjectDetail.businessname = row.Cells["BusinessName"].Value.ToString();
                ProjectDetail.contactperson = row.Cells["ContactPerson"].Value.ToString();
                ProjectDetail.phone = row.Cells["Phone"].Value.ToString();
                ProjectDetail.address = row.Cells["Address"].Value.ToString();
                ProjectDetail.createddate = row.Cells["CreatedDate"].Value.ToString();
                ProjectDetail.assignedto= row.Cells["AssignedTo"].Value.ToString();
                // etc.
            
                ProjectDetail.ShowDialog();
            }            
        }
