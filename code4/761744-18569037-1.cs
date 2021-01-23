	public sealed class EnumValueToDecriptionConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value == null)
			{
				return null;
			}
			var type = value.GetType();
			if(!type.IsEnum)
			{
				return null;
			}
			var field = type.GetField(value.ToString());
			var attr = field.GetCustomAttributes(typeof(DescriptionAttribute), true)
							.Cast<DescriptionAttribute>()
							.FirstOrDefault();
			if(attr != null)
			{
				return attr.Description;
			}
			else
			{
				return field.Name;
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
		#endregion
	}
