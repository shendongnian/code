    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var cell = (DataGridCell)values[0];
        var lockedColumns = (List<int>)values[1];
        var lockedRows = (List<int>)values[2];
        var row = (DataGridRow)values[3];
    
        // how to get the row index? 
        var isLocked = lockedColumns.Contains(cell.Column.DisplayIndex);
        if (!isLocked)
        {
            isLocked = lockedRows.Contains(row.GetIndex());
        }
    
        return (isLocked) ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(Colors.White);
    }
