    public class CustomDGV : DataGridView
    {
        private object _cellValue;
        private Dictionary<int, object[]> _pendingChanges;
        public CustomDGV()
        {
            _pendingChanges = new Dictionary<int, object[]>();
        }
        protected override void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
        {
            // Save the value of the cell before edit
            _cellValue = this[e.ColumnIndex, e.RowIndex].Value;
            // If there's already a pending change for that cell, display the edited value
            if (_pendingChanges.ContainsKey(e.RowIndex))
            {
                this[e.ColumnIndex, e.RowIndex].Value = _pendingChanges[e.RowIndex][e.ColumnIndex];
            }
            base.OnCellBeginEdit(e);
        }
        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            // Adds the edited value of the cell into a dictionary
            if (!_pendingChanges.ContainsKey(e.RowIndex))
            {
                _pendingChanges.Add(e.RowIndex, new object[this.ColumnCount]);
            }
            _pendingChanges[e.RowIndex][e.ColumnIndex] = this[e.ColumnIndex, e.RowIndex].Value;
            // Display the "old" value
            this[e.ColumnIndex, e.RowIndex].Value = _cellValue;
        }
        public void SavePendingChanges(int rowIndex)
        {
            if (_pendingChanges.ContainsKey(rowIndex))
            {
                // Gets the pending changes for that row
                var rowData = _pendingChanges[rowIndex];
                // Update every cell that's been edited
                for(int i = 0; i < rowData.Length; i++)
                {
                    if (rowData[i] != null)
                        this[i, rowIndex].Value = rowData[i];
                }
                // Removes the pending changes from the dictionary once it's saved
                _pendingChanges.Remove(rowIndex);
            }
        }
    }
