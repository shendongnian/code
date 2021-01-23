    public class MyConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
            {
    
                Item listItem = values[0] as Item;
                ObservableCollection<Item> collection = values[1] as ObservableCollection<Item>;
    
                return collection.Contains(listItem);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
                                        System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
