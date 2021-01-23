	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Windows.Data;
	using System.Windows.Documents;
	namespace MyStuff
	{
		public class MergeCollectionsConverter : IMultiValueConverter
		{
			public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
			{
				if (values == null) return null;
				List<object> combinedList = new List<object>();
				foreach (object o in values)
				{
					if (o is IEnumerable)
						combinedList.AddRange( ((IEnumerable) o).Cast<object>() );
					else
						combinedList.Add(o);
				}
				return combinedList;
			}
			public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
			{
				throw new NotImplementedException();
			}
		}
	}
