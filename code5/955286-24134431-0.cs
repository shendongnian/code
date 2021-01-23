    public class CompositeNodeConverter : IValueConverter
        {
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var node = value as Node;
    
                CompositeCollection collection = new CompositeCollection();
                CollectionContainer container = new CollectionContainer();
                container.Collection = node.Child;
                collection.Add(container);
    
                container = new CollectionContainer();
                container.Collection = node.Attributes;
    
                collection.Add(container);
    
                return collection;
    
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
