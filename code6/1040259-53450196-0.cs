        private void dgvResults_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool.TryParse(dgvResults.Rows[e.RowIndex].Cells["IsChanged"].Value.ToString(), out bool bIsChanged);
            if(bisChanged)
               dgvUsers.Rows[e.RowIndex].Cells["MyCellName"].Style.BackColor = Color.Salmon;
        }
 
