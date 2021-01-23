    Binding TestValue, Converter={StaticResource TestConverter}, ConverterParameter='Test'}
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter != null && parameter.Equals("Test"))
            { //Do some operation 
            }
        }
