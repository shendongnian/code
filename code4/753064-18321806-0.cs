    public class ToCommand : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(object value, 
                              Type targetType, 
                              object parameter, 
                              CultureInfo culture)
        {
            if (targetType != tyepof(ICommand))
                return Binding.DoNothing;
            return new DelegateCommand<object>(x => { });
        }
        public object ConvertBack(object value, 
                                  Type targetType, 
                                  object parameter, 
                                  CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
