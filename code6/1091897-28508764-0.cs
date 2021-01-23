    OnMyColumnHelperColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
        DataGrid.Columns.Clear();
        foreach(var column in (IEnumerable)args.NewValue)
        {
            DataGrid.Columns.Add(column);
        }
    }
