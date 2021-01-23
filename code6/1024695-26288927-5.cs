     public class BGConverter : IValueConverter
    {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            GenericQueueViewModel oQueue;
            System.Windows.Media.Brush returnBrush;
            DataGrid oGrid = (DataGrid)parameter;
            if (value == null)
            {
                returnBrush = System.Windows.Media.Brushes.Transparent;
            }
            else if (oGrid == null)
            {
                returnBrush = System.Windows.Media.Brushes.Transparent;
            }
            else if (value.GetType() == typeof(GenericQueueViewModel))
            {
                MainViewModel.Instance.GenericVM = (GenericQueueViewModel)value;
                returnBrush = System.Windows.Media.Brushes.Transparent;
            }
            else
            {
                oQueue = MainViewModel.Instance.GenericVM;
                DataGridColumn oCol = oGrid.Columns.FirstOrDefault(y => y.Header == value);
                int colIndex = oGrid.Columns.IndexOf(oCol);
                string colName = (string)value;
                var fList = oQueue.FilterColumns.FirstOrDefault(y => y.ColumnIndex == colIndex && y.IsFiltered == true);
                if (fList == null)
                {
                    returnBrush = System.Windows.Media.Brushes.Transparent;
                }
                else
                {
                    returnBrush = System.Windows.Media.Brushes.Red;
                }
            }
            return returnBrush;
        }
    }
