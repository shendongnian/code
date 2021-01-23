    using GalaSoft.MvvmLight.Command;
    
        public class RoutedPropertyChangedEventArgsToDoubleConverter : IEventArgsConverter
        {
            public object Convert(object value, object parameter)
            {
                var args = (RoutedPropertyChangedEventArgs<double>)value;
                var element = (FrameworkElement)parameter;
    
                return args.NewValue;
            }
        }
