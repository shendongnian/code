    <DataGrid Name="DataGrid1">
        <DataGrid.RowStyle>
            <Style TargetType="{x:Type DataGridRow}">
                <Setter Property="Background" Value="{Binding rowBackground}"/>
            </Style>
        </DataGrid.RowStyle>
    </DataGrid>
    DataTable Model { get; set; }
    public UserControl1()
    {
        InitializeComponent();
        this.Model = new DataTable() { Locale = CultureInfo.CurrentCulture };
        this.Model.Columns.Add("a", typeof(int));
        this.Model.Columns.Add("b", typeof(string));
        this.Model.Columns.Add("rowBackground", typeof(Brush));
        this.Model.Rows.Add(1, "one", Brushes.White);
        this.Model.Rows.Add(2, "two", Brushes.White);
        this.Model.Rows.Add(3, "three", Brushes.White);
        this.Model.AcceptChanges();
        DataGrid1.ItemsSource = this.Model.DefaultView;
    }
    void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
    {
        Brush brush = new SolidColorBrush(e.NewValue);
        foreach (DataRowView selectedItem in DataGrid1.SelectedItems)
        {
            selectedItem["rowBackground"] = brush;
        }
    }
