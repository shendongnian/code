    using System;
    using System.Linq;
    using System.Globalization;
    using System.Windows.Data;
    
    namespace StackOverFlowTest.Converters
    {
    	class MultiBoolAndConverter : IMultiValueConverter
    	{
    		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    		{
    			return values.Cast<bool>().All(value => value);
    		}
    
    		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    		{
    			throw new NotImplementedException();
    		}
    	}
    }
