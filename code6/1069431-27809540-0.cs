             private void dgvLoadAll_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn dataGridViewColumn = dgvLoadAll.Columns[e.ColumnIndex];
            if (columnsList.Contains(e.ColumnIndex))
            {
                columnsList.Remove(e.ColumnIndex);
                dataGridViewColumn.HeaderCell.Style.BackColor = SystemColors.Control;
            }
            else
            {  
                columnsList.Add(e.ColumnIndex);
                dataGridViewColumn.HeaderCell.Style.BackColor = SystemColors.Highlight;
            }
        }
