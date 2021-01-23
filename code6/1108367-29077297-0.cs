        private void _dgvCoarseAggegateTest_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            var dgv = (DataGridView)sender;
            if (e.ColumnIndex == 2) {
                var cell = (DataGridViewComboBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Items.Clear();
                // Run your dbase query here to fill cell.Items
                //...
                // We'll just fake it here for demo purposes:
                cell.Items.Add(e.RowIndex.ToString());
                cell.Items.Add((e.RowIndex+1).ToString());
                cell.Items.Add((e.RowIndex+2).ToString());
            }
        }
