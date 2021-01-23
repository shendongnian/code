    [ValueConversion(typeof(Category), typeof(String))]
    public class CategoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int category = (int)value;
            string res;
            try
            {
                res = Resources.ResourceManager.GetString(string.Format("Category_{0:d4}", (int)category));
            }
            catch(Exception e)
            {
               res = string.Format("Unable to obtain resource {0}: {1}", Category, e.Message);
            }
            return res;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             throw new NotSupportedException();
        }
    }
