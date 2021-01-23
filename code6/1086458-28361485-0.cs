     class CategoryToColorConverter: IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, string language)
        {
        if((bool)value)
            return Colors.White;
        else
            return Colors.Black;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
          if((bool)value)
              return Colors.Black;
                 else
              return Colors.White;
        }
    }
