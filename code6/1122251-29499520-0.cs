    [ValueConversion(typeof(DateTime), typeof(DateTime))]
    class DateTimeNullConverter: IValueConverter
        {
             public object Convert (object value, Type targetType, object parameter, Culture culture)
             {
                    if (value != null)
                    {
                       DateTime dateTime = (DateTime)value;
                       if (dateTime.Year.ToString == "1")
                           return null;
                       else
                          return dateTime;
                    }
                    else
                    {
                          return null;
                    }
                }
             public object ConvertBack (object value, Type targetType, object parameter, Culture culture)
             {
                  DateTime convertDateTime;
                  if (value == null)
                  {
                      convertDateTime = new DateTime();
                  }
                  else
                  {
                      convertDateTime = (DateTime) value;
                  }
                  return convertDateTime;
             }
        }
