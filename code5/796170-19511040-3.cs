    using System;
    using System.Globalization;
    using System.Windows.Data;
    namespace WpfApplicationTest
    {
	[ValueConversion(typeof(object), typeof(String))]
	public class MyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string name = "";
			if (value != null)
			{
				User user = (User)value;
				name = user.Name;
			}
			else
			{
				name = "";
			}
			return name;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
    }
