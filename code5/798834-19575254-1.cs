    private void fileButton_Click(object sender, RoutedEventArgs e)
    {
    	if (fileButton.ContextMenu.Style == null)
    		fileButton.ContextMenu.Style = this.FindResource("ContextMenuStyle") as Style;
    	fileButton.ContextMenu.IsOpen = true;
    }
