        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // get current cell
                var cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];
                // check new value. i need any number >= 5
                var c0 = 0;
                if (e.FormattedValue == null || !Int32.TryParse(e.FormattedValue.ToString(), out c0) || c0 < 5)
                {
                    // bad value inserted
                    // e.FormattedValue - is new value
                    // cell.Value - contains 'old' value
                    // choose any:
                    cell.Value = cell.Value;    // this way we return 'old' value
                    e.Cancel = true;            // this way we make user not leave the cell until he pastes the value we expect
                }
            }
            catch (Exception ex)
            {
            }
        }
