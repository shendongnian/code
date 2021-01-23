    [ValueConversion(typeof(KeyValuePair<string, Dictionary<string, int>>), typeof(string))]
    public class GridViewColumnInnerDictionaryValue : GridViewColumn, IValueConverter
    {
        public string InnerDictionaryKey
        {
            get { return _key; }
            set
            {
                if (_key == value) return;
                _key = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    DisplayMemberBinding = null;
                }
                else if (DisplayMemberBinding == null)
                {
                    DisplayMemberBinding = new Binding()
                    {
                        Mode = BindingMode.OneWay,
                        Converter = this
                    };
                }
            }
        }
        private string _key = null;
        #region IValueConverter
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is KeyValuePair<string, Dictionary<string, int>>)
            {
                Dictionary<string, int> innerDict = ((KeyValuePair<string, Dictionary<string, int>>) value).Value;
                int dictValue;
                return (innerDict.TryGetValue(InnerDictionaryKey, out dictValue)) ? (object) dictValue : string.Empty;
            }
            throw new NotSupportedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion IValueConverter
    }
