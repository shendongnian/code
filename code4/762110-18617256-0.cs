    public class listToObservableCollection : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            HashSet<Level2> observableList = (HashSet<Level2>)value;
            return new ObservableCollection<Level2>(observableList);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (HashSet<Level2>)value;
        }
    }
    
    public abstract class BaseConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
