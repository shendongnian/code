    public class GridDefinitionConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var definition = value as DefinitionBase;
                int toReturn = 0;
                if (definition != null)
                {
                    var grid = (definition as FrameworkContentElement).Parent as Grid;
    
                    if (grid != null && definition is RowDefinition)
                        toReturn = grid.RowDefinitions.IndexOf(definition as RowDefinition);
    
                    if (grid != null && definition is ColumnDefinition)
                        toReturn = grid.ColumnDefinitions.IndexOf(definition as ColumnDefinition);
                }
                return toReturn;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
