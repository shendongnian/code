    public class IsViewItemConverter : IMultiValueConverter
    {
        /// <summary>
        /// COnverter checks CanDisplayDetails and if ComboBoxItem is View Details, will disable if false and is View Details
        /// </summary>
        /// <param name="values">object array</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>true if should enabled item</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool? b = values[0] as bool?;
            ComboBoxItem c = values[1] as ComboBoxItem;
            InvoiceActionsLong? item = c.Content as InvoiceActionsLong?;
            if (b == false && (InvoiceActionsLong)item == InvoiceActionsLong.View)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
