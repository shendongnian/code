    public class ValueToBrushMultiConverter : IMultiValueConverter
        {
            private const string NBSP = "\u00A0";
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var cell = (DataGridCell)values[0];
                var dgRow = (DataGridRow)values[1];
    
                var test = (dgRow.Item as TableRow<string, string>).Values[cell.Column.DisplayIndex];
                        
                if (test.Contains(NBSP))
                    return System.Windows.Media.Brushes.PaleGreen;
                return DependencyProperty.UnsetValue;           
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
