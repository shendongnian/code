    private void CustomDialogWindow_Close(object sender, RoutedEventArgs e)
    {
        DialogResult = null;
    }
    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
