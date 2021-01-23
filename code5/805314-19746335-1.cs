    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        DataGrid dg = (DataGrid)parameter;
        var itemType = dg.SelectedItems[0].GetType();
        var listType = typeof(List<>).MakeGenericType(itemType);
        return Activator.CreateInstance(listType, dg.SelectedItems);
    }
