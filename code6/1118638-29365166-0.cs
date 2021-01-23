    private void button_WithDoubleClick_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show("Double click");
    }
    private void button_RaiseDoubleClick_Click(object sender, RoutedEventArgs e)
    {
        var args = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left)
        {
            RoutedEvent = Control.MouseDoubleClickEvent
        };
        this.button_WithDoubleClick.RaiseEvent(args);
    }
