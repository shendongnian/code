    public enum EBillType
    {
        Direct , PO
    };
    public class BillTypeToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {           
            EBillType billType = (EBillType)value;
            return billType == EBillType.PO;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
