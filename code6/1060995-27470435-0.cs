        private void dgvProjectDetails__CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            object cell = ((DataGridView)sender)[col, row];
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                frmAddProjects ProjectDetail = new frmAddProjects(); //<= THIS must be created first
                frmAddProjects.projectid = row.Cells["ProjectID"].Value.ToString();
                frmAddProjects.businessname = row.Cells["BusinessName"].Value.ToString();
                frmAddProjects.contactperson = row.Cells["ContactPerson"].Value.ToString();
                frmAddProjects.phone = row.Cells["Phone"].Value.ToString();
                frmAddProjects.address = row.Cells["Address"].Value.ToString();
                frmAddProjects.createddate = row.Cells["CreatedDate"].Value.ToString();
                frmAddProjects.assignedto= row.Cells["AssignedTo"].Value.ToString();
                // etc.
            
                ProjectDetail.ShowDialog();
            }
            //fOtherForm.YourTextBox.Text = value.ToString();
        }
