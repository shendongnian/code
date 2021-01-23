    public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string s = value as string;
            float result;
            if (!string.IsNullOrWhiteSpace(s) && float.TryParse(s, out result))
            {
                return result;
            }
            return null;
        }
