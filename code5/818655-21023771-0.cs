    class FindResultsGrid : Window
    {
        public FindResultsGrid(List<FindResultLine> list)
        {
            var dg = new DataGrid() 
            { 
                AutoGenerateColumns = false, 
                Height = 450, // starting size, will be dynamic based on window...
                Width = 900,
                SelectionMode= DataGridSelectionMode.Single 
            };
            this.Width = dg.Width + 25;
            this.Height = dg.Height + 42;
            dg.AddColumn("Item", "ItemName", width: 151);
            dg.AddColumn("Line #", "lineNbr", width: 51);
            dg.AddColumn("Text", "lineText");
            dg.SetBinding(DataGrid.WidthProperty, new Binding("ActualWidth") { Source = this, Converter=new WidthConversion() });
            dg.SetBinding(DataGrid.HeightProperty, new Binding("ActualHeight") { Source = this, Converter=new HeightConversion() });
        
            this.Content = dg;
            dg.ItemsSource = list;
        }
    }
    class WidthConversion : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((double)value) - 25.0;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) { throw new NotImplementedException(); }
    }
    class HeightConversion : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((double)value) - 42;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) { throw new NotImplementedException(); }
    }
    public static class MyExtensions
    {
        public static DataGridTextColumn AddColumn(this DataGrid dg, string header,
            string propertyPath = null,
            double width = Double.NaN,
            BindingMode way = BindingMode.OneWay,
            bool canUserSort = true)
        {
            if (propertyPath == null)
                propertyPath = header;
            var binding = new System.Windows.Data.Binding(propertyPath);
            binding.Mode = way;
            var col = new DataGridTextColumn()
            {
                Header = header,
                Binding = binding,
                Width = Double.IsNaN(width) ? DataGridLength.Auto : new DataGridLength(width),
                CanUserSort = canUserSort
            };
            dg.Columns.Add(col);
            return col;
        }
