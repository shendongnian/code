    private void row_MouseDown(object sender, MouseButtonEventArgs e)
    {
        DataGridRow row = FindParent<DataGridRow>((Border)sender);
        DataGrid dataGrid = FindParent<DataGrid>(row);
    
        int rowIndex = dataGrid.ItemContainerGenerator.IndexFromContainer(row);
    }
    
    private T FindParent<T>(DependencyObject child) where T : DependencyObject
    {
        var parent = System.Windows.Media.VisualTreeHelper.GetParent(child);
    
        if (parent is T || parent == null)
            return parent as T;
        else
            return FindParent<T>(parent);
    }
