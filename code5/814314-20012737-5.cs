        [ValueConversion(typeof(KeyValuePair<string, Dictionary<string, int>>), typeof(string))]
		public class GetInnerDictionaryValueConverter : IValueConverter
		{
			public string DictionaryKey { get; set; }
			public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				if (!(value is KeyValuePair<string, Dictionary<string, int>>))
					throw new NotSupportedException();
				Dictionary<string, int> innerDict = ((KeyValuePair<string, Dictionary<string, int>>) value).Value;
				int dictValue;
				return (innerDict.TryGetValue(DictionaryKey, out dictValue)) ? (object) dictValue : string.Empty;
			}
			public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
			{
				throw new NotImplementedException();
			}
		}
