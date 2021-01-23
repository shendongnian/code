        namespace MyImageConvertor
        {
            public class MyValueConverter : IValueConverter
            {
                #region IValueConverter Members
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    try
                    {
                        var uri = new Uri((string)(value), UriKind.RelativeOrAbsolute);
                        var img = new BitmapImage(uri);
                        return img;
                    }
                    catch
                    {
                        return new BitmapImage();
                    }
                }
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var img = value as BitmapImage;
                    return img.UriSource.AbsoluteUri;
                }
                #endregion
            }
        }
