    private void OnPreviewMouseUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var source = mouseButtonEventArgs.Source;
            // Assuming the DataGridColumn's Template is just a TextBlock
            // but depending on the Template which for sure should at least inherit from FrameworkElement to have the Parent property.
            var textBlock = source as TextBlock;
            // Not a good check to know if it is a holding dates but it should give you the idea on what to do
            if (textBlock != null)
            {
                var dataGridColumn = textBlock.Parent as DataGridColumn;
                if (dataGridColumn != null)
                {
                    if ((string) dataGridColumn.Header == "Holding Dates")
                    {
                        // Show context menu for holding dates
                    }
                        
                }
            }
                // Other stuff
            else if (somethingElse)
            {
                // Show context menu for other stuff
            }
    }
