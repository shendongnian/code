    private void OnPreviewMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
    {
            var source = mouseButtonEventArgs.Source;
            var dataGridColumn = source as DataGridColumn;
            // Not a good check to know if it is a holding dates but it should give you the idea on what to do
            if (dataGridColumn != null && (string) dataGridColumn.Header == "Holding Dates")
            {
                // Show context menu for holding dates
            }
            // Other stuff
            else if (somethingElse)
            {
                // Show context menu for other stuff
            }
    }
