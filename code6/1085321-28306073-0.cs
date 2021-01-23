    private void UnitDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            _isEditing = true;
        }
    protected override void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
    {
       _isEditing = false;
    }
