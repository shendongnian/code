    static XDataGridComboBox()
    {
        DataRowProperty = DependencyProperty.RegisterAttached(
            "DataRow",
            typeof(DataRow),
            typeof(XDataGridComboBox),
            new FrameworkPropertyMetadata(OnChangeDataRow));
            ItemsFieldNameProperty = DependencyProperty.RegisterAttached(
                "ItemsFieldName",
                typeof(string),
                typeof(XDataGridComboBox),
                new FrameworkPropertyMetadata(OnChangeItemsFieldName));
    }
    private static void OnChangeDataRow(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var comboBox = d as XDataGridComboBox;
        if (comboBox == null)
        {
            return;
        }
        var cell =
            (from DataCell c in comboBox.DataRow.Cells where c.FieldName == comboBox.ItemsFieldName select c)
                .FirstOrDefault();
        if (cell == null)
        {
            return;
        }
        comboBox.ItemsSource = cell.Content as IEnumerable;
    }
