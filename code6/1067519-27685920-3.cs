        public class PrefixPostfixConverter : IMultiValueConverter 
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values == null || values.Length != 3)
                    throw new ArgumentException("values");
                var items = values[0] as IEnumerable;
                var prefix = values[1] as string;
                var postfix = values[2] as string;
                if (items == null || prefix == null || postfix == null)
                    return null;
                return items.Cast<object>()
                            .Select(i => prefix + i + postfix)
                            .ToArray();
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
