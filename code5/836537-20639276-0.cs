    public UserControl1() 
    {
        InitializeComponent();
        ...
        DataGrid1.LoadingRow += DataGrid1_LoadingRow;
    }
    Dictionary<int, Style> rowStyles = new Dictionary<int, Style>();
    void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        int rowIndex = DataGrid1.Items.IndexOf(e.Row.Item);
        if (rowStyles.ContainsKey(rowIndex))
        {
            e.Row.Style = rowStyles[rowIndex];
        }
        else
        {
            e.Row.Style = null;
        }
    }
    
    void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
    {
        Style style = new Style(typeof(DataGridRow));
        style.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(e.NewValue)));
        foreach (object selectedItem in DataGrid1.SelectedItems)
        {
            int rowIndex = DataGrid1.Items.IndexOf(selectedItem);
            rowStyles[rowIndex] = style;
        }
        DataGrid1.Items.Refresh();
    }
