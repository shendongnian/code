    private void row_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DataGridRow row = (DataGridRow)System.Windows.Media.VisualTreeHelper
                                       .GetParent((Border)sender);
    }
