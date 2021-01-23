    private void ContextMenuButton_Click(object sender, RoutedEventArgs e)
    {
        Button button = (sender as Button);
        button.ContextMenu.PlacementTarget = button; //add this line
        button.ContextMenu.IsOpen = true; // How should I open the ContextMenu?
    }
