    private void table_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        // Because I want to respond immediately to the user changing the state of one of the "excluded" cells,
        // I have to detect the dirty state of such a cell changing, then call CommitEdit() in order to explicitly
        // cause the CellValueChanged() event to be raised.
        if (_table.CurrentCellAddress.X == _colExcluded.DisplayIndex)
        {
            _table.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
