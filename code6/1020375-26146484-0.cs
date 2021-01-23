    private void UpdateSelectedPlaces()
    {
        //Clear out the places list each time the user selects a new item (or items)
        _selectedPlaces.Clear();
    
        foreach (DataGridViewRow row in placesGridView.Rows)
        {
            if (row.Cells[0].Value != null && row.Cells[0].Value.Equals(true))
            {
                _selectedPlaces.Add((TripPlace)row.DataBoundItem);
            }
        }
    }
    private void placesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSelectedPlaces();
        }
    private void placesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (placesGridView.IsCurrentCellDirty)
        {
            placesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    
    }
