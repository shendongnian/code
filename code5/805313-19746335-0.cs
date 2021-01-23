    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        DataGrid dg = (DataGrid)parameter;
        return dg.SelectedItems.Cast<object>().ToList();
    }
