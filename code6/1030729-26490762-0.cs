      public class LimitItemsConverter : BaseConverter, IValueConverter
    {
        public LimitItemsConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) { return null; }
            int max = 20;
          
            if (value.GetType().IsGenericType && value is IList)
            {
                
                var list = ((IList)value);
                Type type = list.GetType().GetGenericArguments()[0];
                Type genericListType = typeof(List<>).MakeGenericType(type);
                var reducedList = (IList)Activator.CreateInstance(genericListType);
                int min = Math.Min(max, list.Count);
                for (int i = 0; i < min; i++)
                {
                    reducedList.Add(list[i]);
                }
                return reducedList;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
