    public bool IsEditing { get; set; }
        private void ConfigurationFileView_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            IsEditing = true;
        }
        private void ConfigurationFileView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            IsEditing = false;
        }
