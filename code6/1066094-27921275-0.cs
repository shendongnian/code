        private void DataGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGrid.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.KeyDown += this.DataGridComboBox_KeyDown;
            }
        }
        private void DataGridComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.S) && !(e.Control && e.KeyCode == Keys.C))
            {
                try
                {
                    var currentcell = this.dataGrid.CurrentCellAddress;
                    var sendingCB = sender as DataGridViewComboBoxEditingControl;
                    DataGridViewComboBoxCell cel = (DataGridViewComboBoxCell)this.dataGrid.Rows[currentcell.Y].Cells[0];
                    cel.Value = sendingCB.EditingControlFormattedValue.ToString();
                }
                catch { }
            }
        }
