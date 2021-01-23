        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = string.Empty;
            IEnumerable source = value as IEnumerable;
            if (source != null)
            {
                var v = source.OfType<BaseType>();
                var x = v.Select(c => c.Name);
                text = string.Join(", ", x);
            }
            return text;
        }
