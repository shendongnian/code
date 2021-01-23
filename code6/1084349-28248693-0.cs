    public class MyIdentificationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return string.Join(",", ((List<MainWindowViewModel.Identification>)value).Select(x => x.ArticleNumber));
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
